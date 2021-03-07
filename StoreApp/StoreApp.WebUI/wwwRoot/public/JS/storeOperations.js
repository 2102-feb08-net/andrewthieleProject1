'use strict';


function cancelAction(whatIsCancled) {
  document.getElementById("formArea").innerHTML = `Canceled ${whatIsCancled}`;
  document.getElementById("tableArea").innerHTML = "";
}

function stringHasValidCharacter(str, library) {
  
}

function HeyYouGuys(BecauseILikeGoonies) {
  alert(BecauseILikeGoonies);
}

function LoadCustomerList() {

  return fetch(`/api/customers`).then(response => {
    if(!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
    return response.json();
  });

  
}


function LoadLocationList() {

  return fetch(`/api/locations`).then(response => {
    if(!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
    return response.json();
  });
}

//LoadLocationList();


function LoadProductList() {
  return fetch(`/api/products`).then(response => {
    if(!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
    return response.json();
  });

}


function LoadOrderList() {
  // const orders =  [
  //   {
  //     ID: '1',
  //     Customer: 'Bob Smith',
  //     Location: 'X'
  //   },    
  //   {
  //     ID: '2',
  //     Customer: 'Bob Smith',
  //     Location: 'Y'
  //   },    
  //   {
  //     ID: '3',
  //     Customer: 'Bob Smith',
  //     Location: 'Z'    },    
  // ];

  // const anchor = document.getElementById('orderList');
  // for(const order of orders) {
  //   anchor.appendChild(new Option(`${order.Customer} - ${order.ID}`,`${order.ID}`));
  // }
  return fetch(`/api/orders`).then(response => {
    if(!response.ok) {

      throw new Error(`Network response was not ok (${response.status})`);
    }
    return response.json();
  });


}


function LoadListsForOrders() {
  LoadLocationList();
  LoadCustomerList();
}

function sendCustomer(firstName, lastName) {
  return fetch(`/api/searchCustomer/${firstName}/${lastName}`).then(response => 
   {
    if (!response.ok) {
      const RESULTS_AREA = document.getElementById("searchResultsArea");
      RESULTS_AREA.innerHTML = `Network response was not ok`;

      throw new Error(`Network response was not ok (${response.status})`);

    }
return response.json()})
         
  .then(customer => {
    if (customer === null)
    {
      
    }
    else {
      const RESULTS_AREA = document.getElementById("searchResultsArea");
      RESULTS_AREA.innerHTML = `<h3> Customer found:<br><ul><li>First Name: ${customer.firstName}</li><li>Last Name ${customer.lastName}</li><li>Balance: ${customer.balance}</li></ul>`;
  
  }
});
  
}
