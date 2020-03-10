var request_downloadable_files = new XMLHttpRequest();

// downloadable_files
const downloadable_files_div = document.getElementById('downloadable_files');

request_downloadable_files.open('GET', 'http://localhost:5000/downloadable_files', true);
request_downloadable_files.onload = function () {
    // Begin accessing JSON data here
    var data = JSON.parse(this.response);
    if (request_downloadable_files.status >= 200 && request_downloadable_files.status < 400) {
        console.log('download data: ', data)

        const oneol = document.createElement('ol');
        downloadable_files_div.appendChild(oneol);

        data.filenames.forEach(filename => {
        const oneli = document.createElement('li');
        oneol.appendChild(oneli);

        const onea = document.createElement('a');
        oneli.appendChild(onea)

        onea.href = 'https://www.w3schools.com'
        onea.innerText = filename;
        });

    } else {
        const errorMessage = document.createElement('marquee');
        errorMessage.textContent = `Gah, it's not working!`;
        app.appendChild(errorMessage);
    }
}

// Send request_downloadable_files
request_downloadable_files.send();

