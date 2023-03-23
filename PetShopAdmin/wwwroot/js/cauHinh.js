R.CauHinh = {
    Init: function () {
        R.CauHinh.InitCkEditor();
        R.CauHinh.RegisterEvent();
    },
    RegisterEvent: function () {
        $('#edit-cauhinh').off('click').on('click', function () {
            var Id = $('#Id').val();
            var tenCauHinh = $('#TenCauHinh').val();
            var giaTriCauHinh;
            if ($('#GiaTriCauHinh').attr('src') && $('.upload-single-input').val()) {
                var dt = new FormData();
                dt.append('file', $('.upload-single-input')[0].files[0]);
                //const promise1 = R.UploadFile.DoUpload(dt, $('.upload-single-input'));

                giaTriCauHinh = $('.upload-single-input')[0].files[0].name;
                
                R.UploadFile.DoUpload(dt, $('.upload-single-input'));
                //new Promise(function (resolve, reject) {
                //    const promise1 = R.UploadFile.DoUpload(dt, $('.upload-single-input'));
                //    setTimeout(() => resolve(promise1), 100);
                //}).then(function (result) {
                //    let params = {
                //        Id: Id,
                //        TenCauHinh: tenCauHinh,
                //        GiaTriCauhinh: result,
                //    }

                //    R.CauHinh.EditCauHinh(params);
                //    return 0;
                //})

                //$.when(promise1, promise2).done(function (data1, data2) {
                //    console.log('Data from promise1:', data1);
                //    console.log('Data from promise2:', data2);
                //    window.location.href = "/CauHinhs/Index";
                //}).fail(function (error) {
                //    console.error('Error:', error);
                //});
            } else {
                giaTriCauHinh = CKEDITOR.instances.ckGiaTriCauHinh.getData();

                let params = {
                    Id: Id,
                    TenCauHinh: tenCauHinh,
                    GiaTriCauhinh: giaTriCauHinh,
                }
                R.CauHinh.EditCauHinh(params);
            }
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
        $.ajax({
            url: '/CauHinhs/Edit/' + params.Id,
            type: 'POST',
            data: {
                cauHinh : params
            },
            success: function (result) {
                // Handle success response
                alert("Edit success");
                window.location.href = "/CauHinhs/Index"
            },
            error: function (xhr, status, error) {
                // Handle error response
                console.log(error);
            }
        });
    }  

}
R.CauHinh.Init();