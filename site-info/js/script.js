document.addEventListener("DOMContentLoaded",
    $ajaxUtils.sendGetRequest("/data/info.json",
        function (res) {
            console.log(res);
            var numeroUsuarios = res.oec;
            document.querySelector("#texto-gain").innerHTML = numeroUsuarios;
        })
    );