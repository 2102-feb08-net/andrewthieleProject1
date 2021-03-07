'use strict';

const customerAnchor = document.getElementById('customerList');

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

function AddOrderItemToOrder() {
  let productId = document.getElementById("ProductList").value;
  let customerId = document.getElementById("customerList").value;
  let LocationId = document.getElementById("LocationList").value;

  HeyYouGuys(productId);
  HeyYouGuys(customerId);
  HeyYouGuys(LocationId);
}