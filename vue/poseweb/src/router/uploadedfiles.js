// uploaded_files

var request_uploaded_files = new XMLHttpRequest();

const uploaded_files_div = document.getElementById('uploaded_files');

request_uploaded_files.open('GET', 'http://localhost:5000/uploaded_files', true);
request_uploaded_files.onload = function () {
    // Begin accessing JSON data here
    var data = JSON.parse(this.response);
    if (request_uploaded_files.status >= 200 && request_uploaded_files.status < 400) {
        console.log('upload data: ', data)

        const oneol = document.createElement('ol');
        uploaded_files_div.appendChild(oneol);

        data.filenames.forEach(filename => {
        const oneli = document.createElement('li');
        oneol.appendChild(oneli);

        const onea = document.createElement('a');
        oneli.appendChild(onea)

        onea.innerText = filename;
        });

    } else {
        const errorMessage = document.createElement('marquee');
        errorMessage.textContent = `Gah, it's not working!`;
        app.appendChild(errorMessage);
    }
}

// Send request_uploaded_files
request_uploaded_files.send();
