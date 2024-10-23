window.JavaSc = (url, token) => {
    console.log("OK");
    let surl = `https://${url}/api/Authors/`;

   
    let formData = new FormData();
    formData.append('name', $('#name').val());
    formData.append('about', $('#about').val());
    formData.append('imageFile', $('#imageFile')[0].files[0]);

    let headers = {
        Authorization: `Bearer ${token}`
    };
    console.log(headers);
    let ready = false;

    return new Promise((resolve, reject) => {
    $.ajax({
        type: "POST",
        url: surl,
        headers: headers,
        data: formData, 
        contentType: false,  
        processData: false, 
        success: function (response) {
            console.log("Author created successfully:", response);
            resolve(response.isSuccess)
        },
        error: function (xhr, status, error) {
            console.log("Error:", error);
            resolve(false)
        }
    });
});
    return ready
};
