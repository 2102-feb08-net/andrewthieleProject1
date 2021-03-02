function placeOrder() {
  // alert("You totally picked this");
  let form = document.getElementById("formArea")
  formingOrderForm = `  <form action="" method="post">
  <fieldset>
    <legend>Place Order</legend>
    <select name="" id="">Customer<option value=""></option>
      <option value=""></option>
      <option value=""></option>
      <option value=""></option>
      <option value=""></option>
    </select>
    <select name="" id="">Location<option value=""></option>
      <option value=""></option>
      <option value=""></option>
      <option value=""></option>
      <option value=""></option>
    </select>
    <select name="" id="">Location<option value=""></option>
      <option value=""></option>
      <option value=""></option>
      <option value=""></option>
      <option value=""></option>
    </select>
    <label for=""><input type="number"></label>
    <div>
      <button onclick="cancel('Placing Order')">Cancel</button>
      <button>Add </button>
      <button type="submit" id="formActionBtn">Place</button>
    </div>
  </fieldset>
</form>
`
  form.innerHTML = formingOrderForm;
}

function cancelAction(whatIsCancled) {
  document.getElementById("formArea").innerHTML = `Canceled ${whatIsCancled}`;
  document.getElementById("tableArea").innerHTML = "";
}

function stringHasValidCharacter(str, library) {
  
}

function HeyYouGuys(BecauseILikeGoonies) {
  alert(BecauseILikeGoonies);
}

function MakeTwoTextEntryForm(title, btnLabel, cancelfxn, actionFxn) {
  let createGenericForm = `<form action="" method="post">
  <fieldset><legend></legend>
    <div>
      <label for="">First Name<input type="text" name="fname" id="fname" placeholder="Bob" required minlength="1"></label>
      <label for="">Last Name<input type="text" name="lname" id="lname" placeholder="Smith" required minlength="1"></label>
    </div>
    <div>
     <button id="cancelBtn" type="button">Cancel</button>
      <button id="formActionBtn" type="button" ></button>
    </div>
  </fieldset>
</form>`;

document.getElementById("formArea").innerHTML = createGenericForm;
document.querySelector("legend").innerText = title;
document.querySelector("#formActionBtn").innerText = btnLabel;
document.querySelector("#cancelBtn").onclick = ()=>cancelfxn(title);
document.querySelector("#formActionBtn").onclick = actionFxn;

}

function AddCustomer2Database() {
  HeyYouGuys('Doing add customer stuff');
  let fname = document.querySelector("#fname").value;
  let lname = document.querySelector("#lname").value;
  document.querySelector("#tableArea").innerHTML = `Customer ${fname} ${lname} added.`;
}

function Search4Customer() {
  HeyYouGuys('Ooooo searching for the holy grail....');
}

function MakeDropDownForm(title, btnLabel, cancelfxn, actionFxn, dropDownItems) {
  let createGenericForm = `<form action="" method="post">
  <fieldset>
    <legend></legend>
    <div id="dropDownMenu">

    </div>
    <div>
      <button id="cancelBtn" type="button">Cancel</button>
      <button id="formActionBtn" type="button"></button>
    </div>
  </fieldset>
</form>`;
document.getElementById("formArea").innerHTML = createGenericForm;
document.querySelector("legend").innerText = title;
document.querySelector("#formActionBtn").innerText = btnLabel;
document.querySelector("#cancelBtn").onclick = ()=>cancelfxn(title);
document.querySelector("#formActionBtn").onclick = actionFxn;

}

function ViewOrder() {
  HeyYouGuys('Viewing an order');
}

function MakeAnOrder() {
  let createGenericForm = ``;
}