R.UploadFile = {
    Init: function () {
        R.UploadFile.RegisterEvent();
    },
    RegisterEvent: function () {
        $('.upload-single-input').off('change').on('change', function () {
            var input = $(this)[0]
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.preview-picture').attr('src', e.target.result).width(480).height(300)
                };
                reader.readAsDataURL(input.files[0]);
            }
        })
    },
    DoUpload: function (dt, element) {
        var Id = $('#Id').val();
        var tenCauHinh = $('#TenCauHinh').val();
        $.ajax({
            method: 'post',
            url: '/UploadFiles/UploadSingleFile',
            data: dt,
            contentType: false,
            processData: false,
            success: function (response) {
                var url = response.replace('\\', '/')
                let params = {
                        Id: Id,
                        TenCauHinh: tenCauHinh,
                        GiaTriCauhinh: url,
                }
                R.CauHinh.EditCauHinh(params);
            },
            error: function (err) {
                console.log(err)
            }
        })
    }
}
R.UploadFile.Init();