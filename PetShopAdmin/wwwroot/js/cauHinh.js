R.CauHinh = {
    Init: function () {
        R.CauHinh.InitCkEditor();
        R.CauHinh.RegisterEvent();
    },
    RegisterEvent: function () {
        $('#edit-cauhinh').off('click').on('click', function () {
            var tenCauHinh = $('#TenCauHinh').val();
            var giaTriCauHinh = $('#GiaTriCauHinh').attr('src') ? $('#GiaTriCauHinh').attr('src') : CKEDITOR.instances.ckGiaTriCauHinh.getData();
            var params = {
                Id: 0,
                TenCauHinh: tenCauHinh,
                GiaTriCauhinh: giaTriCauHinh,
            }
            EditCauHinh(params);
        })

    },
    InitCkEditor: function () {
        CKEDITOR.replace('ckGiaTriCauHinh');
        R.CauHinh.RegisterEvent();
    },
    CreateCauHinh: function (params) {
        $.post('/CauHinhs/Create', params, function (response) {
            alert('Them moi thanh cong!');
            window.location.href = "/CauHinhs/Index"
        })
    },
    EditCauHinh: function (params) {
        $.post('/CauHinhs/Edit', params, function (response) {
            alert('Chinh sua thanh cong!');
            window.location.href = "/CauHinhs/Index"
        })
    }


}
R.CauHinh.Init();