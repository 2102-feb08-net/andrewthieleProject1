`use strict`;

const ANCHOR = document.getElementById("orderList");

const GET_ORDER_DATA = document.getElementById("actionButton");

LoadOrderList().then(orders => {
  for(const order of orders) {
    ANCHOR.appendChild(new Option(`Order ID: ${order.id}`,`${order.id}`))
  }
});

GET_ORDER_DATA.addEventListener("click", () => {
  HeyYouGuys("CLICK EENT WORKS");
});