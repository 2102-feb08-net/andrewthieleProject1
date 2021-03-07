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

  DisplayCustomerOrders(whichCustomerID);

  // DISPLAY_AREA.innerHTML = `<p>${whichCustomerID}</p>`;
});

function DisplayCustomerOrders(whichCustomerID) {
  const INFO_BOARD = document.getElementById("Table Here")
  INFO_BOARD.innerHTML = ``;
  return fetch(`/api/order/customer/${whichCustomerID}`).then(response => {
    if(!response.ok) {
      INFO_BOARD.innerHTML = `<h3> Order NOT FOUND </h3>`;
      throw new Error(`Network response was not ok (${response.status})`);
    }
    return response.json();
  }).then(orderhistory =>{
    if(orderhistory.length === 0)
    {
      INFO_BOARD.innerHTML = `THIS CUSTOMER HAS NO ORDERS`;
      return;
    } else {
      INFO_BOARD.innerHTML = ``;

      orderhistory.forEach(element => {
        if(element === null)
        {
          
        }
        let row = document.createElement("p");
        row.innerHTML = `Order ID: ${element.id} Location ID: ${element.locationId}`
        INFO_BOARD.appendChild(row);
        element.orderItems.forEach(orderedItem => {
          let orderedItemRow = document.createElement("p");
          orderedItemRow.innerHTML = `PRODUCT ID: ${orderedItem.productId} QUANTITY: ${orderedItem.quantity}`;
          INFO_BOARD.appendChild(orderedItemRow);
        })
      });
    }
  });
}


