R.Service = {
    Init: function () {
        R.Service.InitCkEditor();
        R.Service.RegisterEvent();
    },
    RegisterEvent: function () {
        $('#edit-service').off('click').on('click', function () {
            var Id = $('#Id').val();
            var Name = $('#Name').val();
            var Image = $('#Image').val();
            var OriginalPrice = $('#OriginalPrice').val();
            var Price = $('#Price').val();
            var Description = $('#Description').val();
            var Specification = CKEDITOR.instances.ckGiaTriCauHinh.getData();

            let params = {
                Id: Id,
                Name: Name,
                Image: Image,
                OriginalPrice: OriginalPrice,
                Price: Price,
                Description: Description,
                Specification: Specification
            }
            R.Service.EditCauHinh(params);
        })
},
    InitCkEditor: function () {
        CKEDITOR.replace('ckGiaTriCauHinh');
        R.Service.RegisterEvent();
    },
CreateService: function (params) {
    $.post('/Services/Create', params, function (response) {
        alert('Them moi thanh cong!');
        window.location.href = "/Services/Index"
    })
},
EditService: function (params) {
    $.ajax({
        url: '/Services/Edit/' + params.Id,
        type: 'POST',
        data: {
            product: params
        },
        success: function (result) {
            // Handle success response
            alert("Edit success");
            window.location.href = "/Services/Index"
        },
        error: function (xhr, status, error) {
            // Handle error response
            console.log(error);
        }
    });
}

}
R.Service.Init();