`use strict`;
// HeyYouGuys('WHOOOOOOO')

const SEARCHBUTTON = document.getElementById("actionBtn");
// SEARCHBUTTON.addEventListener("click", sendCustomer(FIRST_NAME, LAST_NAME))
SEARCHBUTTON.addEventListener("click", () =>{
  const FIRST_NAME = document.getElementById("firstName").value;
  const LAST_NAME = document.getElementById("lastName").value;
  
  sendCustomer(FIRST_NAME, LAST_NAME);});

