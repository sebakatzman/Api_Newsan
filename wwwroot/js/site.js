const uri = 'api/tareas';
let todos = [];

function getItems() {
    //Agarro el filtro de estado y description y si tienen , se lo paso a la url.
    var selectFilterState = document.getElementById('filtroEstado');
    var dataFilterState = selectFilterState.options[selectFilterState.selectedIndex].text;
    console.log("dato del select filtro " + dataFilterState);
    var descriptionFilter = document.getElementById('filtroDescription');
    console.log("aca abajo va lo de descr");
    console.log(descriptionFilter.value.trim());
    var url = uri + "?description=" + (descriptionFilter.value.trim() != "" ? descriptionFilter.value.trim() : "nada") + "&state=" + (dataFilterState != "" ? dataFilterState : "nada");

    console.log(url);
  fetch(url)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get items.', error));
}

function filtrarDatos() {

  getItems();

}

//Inserta una tarea.
function addItem() {
  const addDescriptionTextBox = document.getElementById('description');
  const addStateTextBox = document.getElementById('state');
  const addPhotoTextbox = document.getElementById('photo');
  const item = {
    description: addDescriptionTextBox.value.trim(),
    state: addStateTextBox.value,
    photo: addPhotoTextbox.value.trim(),
  };

  fetch(uri, {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })
    .then(response => response.json())
    .then(() => {
      getItems();
      addDescriptionTextBox.value = '';
      addStateTextBox.value = '';
      addPhotoTextbox.value = '';
    })
    .catch(error => console.error('Unable to add item.', error));
}

//Elimina una tarea.
function deleteItem(id) {
  fetch(`${uri}/${id}`, {
    method: 'DELETE'
  })
  .then(() => getItems())
  .catch(error => console.error('Unable to delete item.', error));
}

//Levanta los datos del registro y los pone en los campos de edicion.
function displayEditForm(id) {
    //Obtengo el registro en especifico
  const item = todos.find(item => item.id === id);
  
  document.getElementById('edit-description').value = item.description;
  document.getElementById('edit-state').value = item.state;
  document.getElementById('edit-id').value = item.id;
  document.getElementById('edit-photo').value = item.photo;
  document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
  const itemId = document.getElementById('edit-id').value;
  const item = {
    id: parseInt(itemId, 10),
    description: document.getElementById('edit-description').value.trim(),
    state: document.getElementById('edit-state').value.trim(),
    photo: document.getElementById('edit-photo').value.trim(),
  };
  console.log(item);
  console.log("id " + itemId);

  fetch(`${uri}/${itemId}`, {
    method: 'PUT',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })
  .then(() => getItems())
  .catch(error => console.error('Unable to update item.', error));

  closeInput();

  return false;
}


function changeState(id) {
    const tarea = todos.find(item => item.id === id);
  
    const objeto = {
        id: parseInt(tarea.id),
        description: tarea.description,
        state: "realizada",
        photo: tarea.photo,
      };
      console.log("objeto sin cambio " + tarea);
      console.log("objeto con cambio " + objeto);
    fetch(`${uri}/${id}`, {
      method: 'PUT',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(objeto)
    })
    .then(() => getItems())
    .catch(error => console.error('Unable to update item.', error));
  
    closeInput();
  
    return false;
  }

function closeInput() {
  document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
  const name = (itemCount === 1) ? 'to-do' : 'to-dos';

  document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {
  const tBody = document.getElementById('todos');
  tBody.innerHTML = '';

  _displayCount(data.length);

  const button = document.createElement('button');

  data.forEach(item => {

    let editButton = button.cloneNode(false);
    editButton.innerText = 'Edit';
    editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

    let deleteButton = button.cloneNode(false);
    deleteButton.innerText = 'Delete';
    deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

        let changeStateButton = button.cloneNode(false);
        changeStateButton.innerText = 'Change State';
        changeStateButton.setAttribute('onclick', `changeState(${item.id})`); 
    
    let tr = tBody.insertRow();
    
    let td1 = tr.insertCell(0);
    let desc = document.createTextNode(item.description);
    td1.appendChild(desc);

    let td2 = tr.insertCell(1);
    let state = document.createTextNode(item.state);
    td2.appendChild(state);

    let td3 = tr.insertCell(2);
    let a = document.createElement('a');
    var link = document.createTextNode("Go to Photo");
    a.appendChild(link); 
    a.title = "This is Link"; 
    a.href = item.photo; 
    a.target = "_blank";
    td3.appendChild(a);

    let td4 = tr.insertCell(3);
    td4.appendChild(editButton);

    let td5 = tr.insertCell(4);
    td5.appendChild(deleteButton);

    let td6 = tr.insertCell(5);
    if (item.state == "pendiente")
        td6.appendChild(changeStateButton);
  
  });

  todos = data;
}