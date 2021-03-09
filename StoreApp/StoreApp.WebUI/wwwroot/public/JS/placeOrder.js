'use strict';

const customerAnchor = document.getElementById('customerList');

const ORDERLIMIT = 50;

let OrderedItems = [];

let Order =  {
    "customerId": undefined,
    "orderItems": [],
    "locationId": undefined
  }

let ORDERTOTAL = 0;

let PRODUCTS = [];


let hasAnOrder = false;

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
  // debugger;
  for(const product of products) {
    productAnchor.appendChild(new Option(`${product.name} : ${product.price}`,`${product.id}`));
    PRODUCTS.push({
      "id": Number(product.id),
      "name": product.name,
      "description": product.description,
      "price": Number(product.price)
    });
  }
});

const DISPLAY_ORDERED_ITEM_AREA = document.getElementById("orderResults");

const ADD_TO_ORDER_BUTTON = document.getElementById("actionBtn");

ADD_TO_ORDER_BUTTON.addEventListener("click", AddOrderItemToOrder);


// Addes an order item to an order
function AddOrderItemToOrder() {
  let productId = document.getElementById("ProductList").value;
  let customerId = document.getElementById("customerList").value;
  let LocationId = document.getElementById("LocationList").value;
  let quantity = document.getElementById("quantity").value;

  if(quantity > ORDERLIMIT) {
    HeyYouGuys('Unacceptable quantity');
    return; 
  }

// who says == isn't useful
  if(quantity == false) {
    HeyYouGuys('Order an item please');
    return;
  }
  
  // add customer id and location id to order

  Order["customerId"] = Number(customerId);
  Order["locationId"] = Number(LocationId);

  // add ordered items to Order.orderItems
  let currentItemOrdered = {
    "productId": Number(productId),
    "quantity": Number(quantity)
  }

  // adjust order total
  debugger;
  ORDERTOTAL += Number(quantity) * Number(PRODUCTS[currentItemOrdered["productId"]].price);
  // test to see what is in order
  Order.orderItems.push(currentItemOrdered);

  // Order.orderItems.forEach(element => {
  //   HeyYouGuys(element.productId);
  //   HeyYouGuys(element.quantity);
  // })
  // make table?
  if(Order.orderItems.length > 0) {
    DISPLAY_ORDERED_ITEM_AREA.removeAttribute("hidden");
  }

  let tableBody = document.getElementById("addOrderedItemsHere");
  let tableRow = document.createElement("tr");
  let productItem = document.createElement("td");
  productItem.innerText = Number(currentItemOrdered["productId"]);
  let productQuantity = document.createElement("td");
  productQuantity.innerText = Number(currentItemOrdered["quantity"]);
  tableRow.appendChild(productItem);
  tableRow.appendChild(productQuantity);
  tableBody.appendChild(tableRow);

}

/// submitts order
function SubmitOrder() {
  // sumbit order

  console.log(Order);

  return fetch(`/api/addOrder`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body:JSON.stringify(Order)
    
    
  }).then(response => {
    if (!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    } else {
      UpdateCustomerBalance(Number(Order["customerId"]),ORDERTOTAL);
      Order.orderItems.forEach(productOrdered => {
        debugger;
        UpdateProductQuantityInStoreWith(
          Number(document.getElementById("LocationList").value),
          Number(productOrdered["productId"]),
          Number(productOrdered["quantity"]));
      });
       // clear Order object
        Order =  {
          "customerId": undefined,
          "orderItems": [],
          "locationId": undefined
        }
      // clear display area
      document.getElementById("addOrderedItemsHere").innerHTML = ``;
      DISPLAY_ORDERED_ITEM_AREA.hidden = true;
      document.getElementById("orderAccepted").hidden = false;
      
    }
  });
}

/// Removes thank you 
function RemoveThankYou() {
  document.getElementById("orderAccepted").hidden = true;
}

/// Updates Customer balance
function UpdateCustomerBalance(id, balance) {
  return fetch(`/api/update/customer/balance/${id}/${balance}`).then(response => {
    if(!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
  });
}

/// Updates inventory in the store
function UpdateProductQuantityInStoreWith(storeId, productId, quantity) {
  return fetch(`/api/adjust/inventory/${storeId}/${productId}/${quantity}`).then(response => {
    if(!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
  });
}

function sendMessage(message) {
  return fetch('/api/send-message', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(message)
  }).then(response => {
    if (!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
  });
}