var butons = {
    deleteBtn:`<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-x" viewBox="0 0 16 16">
    <path d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z"/>
    </svg>`,
    updateBtn:`<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-clockwise" viewBox="0 0 16 16">
        <path fill-rule="evenodd" d="M8 3a5 5 0 1 0 4.546 2.914.5.5 0 0 1 .908-.417A6 6 0 1 1 8 2v1z" />
        <path d="M8 4.466V.534a.25.25 0 0 1 .41-.192l2.36 1.966c.12.1.12.284 0 .384L8.41 4.658A.25.25 0 0 1 8 4.466z" />
        </svg>`
}

const task = document.getElementById("task")
const ulDom = document.getElementById("list")
const addBtn = document.querySelector(".button")
getItems()

//Input boş mu diye kontrol ediliyor.
addBtn.addEventListener("click", function () {
    if (addBtn.innerHTML == "Ekle") {
        if (task.value.trim() == "") {
            alert("Boş karakter eklenemez.")
        }
        else {
            addItems()
            task.value = ""
        }
    }
})

//Veritabanından itemleri getirme metodu //GET
function getItems() {
    fetch("https://localhost:5000/api/todo").then(
        response => { return response.json() })
        .then(responseJson => {
            ulDom.innerHTML = ""
            responseJson.forEach(item => {
                let liDom = document.createElement('li')
                liDom.innerHTML = item.toDoStr
                liDom.id = item.toDoID
                if(item.isActive == true){
                liDom.style.backgroundColor="chartreuse"}
                let btn = deleteButton(item.toDoID, liDom)
                liDom.append(btn)
                let btnU = updateItem(item.toDoID, liDom)
                liDom.append(btnU)
                ulDom.append(liDom)
                liDom.addEventListener('click', function(){
                    liDomColor(item);
                })
            })
        })
}

//İtem silme metodu //DELETE
function deleteButton(liID, liDom) {
    let btn = document.createElement('button');
    btn.innerHTML = butons.deleteBtn;
    btn.classList.add('btn');
    btn.addEventListener("click", function () {
        liDom.parentNode.removeChild(liDom)
        fetch(`https://localhost:5000/api/todo/${liID}`, {
            method: "DELETE",
        })

    })
    return btn;
}

//Veritabanına item ekleme metodu //POST
function addItems() {
    fetch("https://localhost:5000/api/todo", {
        method: 'POST',
        body: JSON.stringify({
            toDoStr: `${task.value}`,
            isActive: false
        }),
        headers: { "Content-type": "application/json; charset=UTF-8" }
    })
        .then(res => { getItems(); })
}

//İtem güncelleme metodu
function updateItem(liID, liDom) {
    let btn = document.createElement('button');
    btn.innerHTML = butons.updateBtn
    btn.classList.add('btn')
    btn.addEventListener("click", function () {
        task.value = liDom.innerText.trim()
        liDom.parentNode.removeChild(liDom)
        addBtn.innerHTML = "Düzenle"
        addBtn.addEventListener("click", function () {
            var myHeaders = new Headers();
            myHeaders.append("Content-Type", "application/json");

            var raw = JSON.stringify({
                "toDoStr": task.value,
                "isActive": false
            });

            var requestOptions = {
                method: 'PUT',
                headers: myHeaders,
                body: raw,
                redirect: 'follow'
            };

            fetch(`https://localhost:5000/api/todo/${liID}`, requestOptions)
                .then(res => {
                    getItems()
                    task.value = ""
                    addBtn.innerHTML = "Ekle"
                    liID = 1
                })
        })
    })
    return btn
}

function liDomColor(item){
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    var raw = JSON.stringify({
    "toDoStr": item.toDoStr,
    "isActive": item.isActive ? false : true
    });

    var requestOptions = {
        method: 'PUT',
        headers:myHeaders,
        body: raw,
        redirect: 'follow'
    };
        
    fetch(`https://localhost:5000/api/todo/${item.toDoID}`, requestOptions)
        .then(response => response.text())
        .then(res=>{getItems()})
        
}