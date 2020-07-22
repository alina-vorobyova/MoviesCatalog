
$(document).ready(function () {
    $("#submit-btn").prop("disabled", true);

    $(".form-input").on("input", function () {
        $("#submit-btn").prop("disabled", false);
    });

    $("#file").on("input", function () {
        Validation();
    });
});

function Validation() {
    document.getElementById("fileValidationSpan").innerHTML = "";
    var success = Filevalidation();
    if (success) {
        ValidateExtension();
    }
}

Filevalidation = () => {
    var fileInput = document.getElementById('file');
    var fileValidationSpan = document.getElementById('fileValidationSpan');
    var submitBtn = document.getElementById("submit-btn");
    // Check if any file is selected.
    if (fileInput.files.length > 0) {
        for (var i = 0; i <= fileInput.files.length - 1; i++) {
            var fsize = fileInput.files.item(i).size;
            var file = Math.round((fsize / 1024));
            // The size of the file.
            if (file > 10096) {
                fileInput.value = null;
                fileValidationSpan.innerText = 'File too big! Maximum allowed file size is 10 MB';
                submitBtn.disabled = true;
                return false;
            }
        }
    }
    submitBtn.disabled = false;
    return true;
}

ValidateExtension = () => {
    var submitBtn = document.getElementById("submit-btn");
    var allowedFiles = [".png", ".jpg", ".jpeg"];
    var fileUpload = document.getElementById("file");
    var lblError = document.getElementById("fileValidationSpan");
    var regex = new RegExp("([a-zA-Z0-9\s_\\.\-:])+(" + allowedFiles.join('|') + ")$");
    if (!regex.test(fileUpload.value.toLowerCase())) {
        fileUpload.value = null;
        lblError.innerHTML = "This photo extension is not allowed!";
        submitBtn.disabled = true;
        return false;
    }
    submitBtn.disabled = false;
    return true;
}

