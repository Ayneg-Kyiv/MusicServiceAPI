window.AddAuthor = (url, token) => {
    console.log("OK");
    let surl = `https://${url}/api/Authors/`;

    let formData = new FormData();
    formData.append('name', $('#name').val());
    formData.append('about', $('#about').val());
    formData.append('imageFile', $('#imageFile')[0].files[0]);

    let headers = {
        Authorization: `Bearer ${token}`
    };

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

window.AddGenre = (url, token) => {
    console.log("OK");
    let surl = `https://${url}/api/Genre/`;

    let formData = new FormData();
    formData.append('name', $('#name').val());
    formData.append('description', $('#description').val());

    let headers = {
        Authorization: `Bearer ${token}`
    };

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

window.AddMelody = (url, token) => {
    console.log("OK");
    let surl = `https://${url}/api/Melodies/`;

    let formData = new FormData();
    formData.append('title', $('#title').val());
    formData.append('duration', $('#duration').val());
    formData.append('authorId', $('#authorId').val());
    formData.append('audioFile', $('#audioFile')[0].files[0]);
    formData.append('imageFile', $('#imageFile')[0].files[0]);

    let headers = {
        Authorization: `Bearer ${token}`
    };
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
                console.log("XHR Response:", xhr.responseText);
                resolve(false)
            }
        });
    });
    return ready
};

window.PromoteToGenre = (url, token, melodyId, genreId) => {
    console.log("OK");
    let surl = `https://${url}/api/ConnectiveTables/GenreToMelody/`;

    let formData = new FormData();
    formData.append('fromId', genreId);
    formData.append('toId', melodyId);

    let headers = {
        Authorization: `Bearer ${token}`
    };

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
                resolve(response.isSuccess)
            },
            error: function (xhr, status, error) {
                resolve(false)
            }
        });
    });
    return ready
};