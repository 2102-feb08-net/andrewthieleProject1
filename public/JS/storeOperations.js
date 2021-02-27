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

function cancel(whatIsCancled) {
  document.getElementById("formArea").innerHTML = `${whatIsCancled} canceled`;
  document.getElementById("tableArea").innerHTML = "";
}

function add2OrderTable() {

}

function MakeForm(does, actionBtnName, cancelMsg, action1, action2) {
  let createGenericForm = `<form action="" method="post">
  <fieldset><legend></legend>
    <div>
      <label for="">First Name<input type="text" name="" id="" placeholder="Bob"></label>
      <label for="">Last Name<input type="text" name="" id="" placeholder="Smith"></label>
    </div>
    <div>
      <button id="cancel" type="button">Cancel</button><button id="formActionBtn" type="button"></button>
    </div>
  </fieldset>
</form>`

document.getElementById("formArea").innerHTML = createGenericForm;
document.querySelector("legend").innerText = does;
document.getElementById("formActionBtn").innerText = actionBtnName;
document.getElementById("cancel").addEventListener('click', action1(cancelMsg));
document.getElementById("formActionBtn").addEventListener('click', action2);

}

function MakeOrderForm() {

}
