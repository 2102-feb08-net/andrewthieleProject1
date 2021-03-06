'use strict';
// HeyYouGuys('HEY YOU GUYS!!!!');
const anchor = document.getElementById('customerList');

const GET_CUSTOMER_ORDER_DATA = document.getElementById("actionButton");



LoadCustomerList().then(customers => {
  for (const customer of customers) {
    anchor.appendChild(new Option(`${customer.firstName} ${customer.lastName}`,`${customer.id}`));
  }

  return;

});

GET_CUSTOMER_ORDER_DATA.addEventListener("click", () => {
  const whichCustomerID = document.getElementById("customerList").value;

  // HeyYouGuys(whichCustomerID);

  const DISPLAY_AREA = document.getElementById("Table Here");

  DISPLAY_AREA.innerHTML = `<p>${whichCustomerID}</p>`;
});


