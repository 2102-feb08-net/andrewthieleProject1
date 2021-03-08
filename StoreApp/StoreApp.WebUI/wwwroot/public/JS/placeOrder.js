'use strict';

const customerAnchor = document.getElementById('customerList');

const ORDERLIMIT = 50;

let OrderedItems = [];

let Order =  {
    "customerId": undefined,
    "orderItems": [],
    "locationId": undefined
  }


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
  
  for(const product of products) {
    productAnchor.appendChild(new Option(`${product.name}`,`${product.id}`));
  }
});

const DISPLAY_ORDERED_ITEM_AREA = document.getElementById("orderResults");

const ADD_TO_ORDER_BUTTON = document.getElementById("actionBtn");

ADD_TO_ORDER_BUTTON.addEventListener("click", AddOrderItemToOrder);

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

// {
//   "customerId": 0,
//   "timeOfOrder": "2021-03-08T02:52:58.207Z",
//   "orderItems": [
//     {
//       "productId": 0,
//       "quantity": 0
//     }
//   ],
//   "locationId": 0,
// }

function SubmitOrder() {
  // sumbit order
  // Order["timeOfOrder"] = undefined;

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

function RemoveThankYou() {
  document.getElementById("orderAccepted").hidden = true;
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