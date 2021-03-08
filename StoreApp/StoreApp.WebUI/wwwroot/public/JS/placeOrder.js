'use strict';

const customerAnchor = document.getElementById('customerList');

const ORDERLIMIT = 50;

let OrderedItems = [];

let Order =  {
    "customerId": undefined,
    "timeOfOrder": undefined,
    "orderItems": [],
    "locationId": undefined
  }

LoadCustomerList().then(customers => {
  for (const customer of customers) {
    customerAnchor.appendChild(new Option(`${customer.firstName} ${customer.lastName}`,`${customer.id}`));

  }
});

const locationAnchor = document.getElementById('LocationList');
LoadLocationList().then(locations => {
for( const location of locations) {
  locationAnchor.appendChild(new Option(`${location.code} `,`${location.id}`));
}
});

const productAnchor = document.getElementById('ProductList');

LoadProductList().then(products => {
  
  for(const product of products) {
    productAnchor.appendChild(new Option(`${product.name}`,`${product.id}`));
  }
});

const DISPLAY_ORDERED_ITEM_AREA = document.getElementById("orderResults");

const ADD_TO_ORDER_BUTTON = document.getElementById("actionBtn");

ADD_TO_ORDER_BUTTON.addEventListener("click", AddOrderItemToOrder);

function AddOrderItemToOrder() {
  let productId = document.getElementById("ProductList").value;

  HeyYouGuys(customerId);
  // let customerId = document.getElementById("customerList").value;
  // let LocationId = document.getElementById("LocationList").value;
  let quantity = document.getElementById("quantity").value;

  if(quantity > ORDERLIMIT) {
    HeyYouGuys('Unacceptable quantity');
    return; 
  }

  let currentItemOrdered = {
    "productId": productId,
    "quantity": quantity
  },






}

