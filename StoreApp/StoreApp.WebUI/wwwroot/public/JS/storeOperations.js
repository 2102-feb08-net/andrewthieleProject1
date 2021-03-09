'use strict';

// Alert fxn
function HeyYouGuys(BecauseILikeGoonies) {
  alert(BecauseILikeGoonies);
}

//gets all available cutomers via GET request
function LoadCustomerList() {

  return fetch(`/api/customers`).then(response => {
    if(!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
    return response.json();
  });

  
}

// gets all locations via GET request
function LoadLocationList() {

  return fetch(`/api/locations`).then(response => {
    if(!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
    return response.json();
  });
}

//LoadLocationList();

// gets all products via GET request
function LoadProductList() {
  return fetch(`/api/products`).then(response => {
    if(!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
    return response.json();
  });

}

// loads all orders via a GET request
function LoadOrderList() {
  return fetch(`/api/orders`).then(response => {
    if(!response.ok) {

      throw new Error(`Network response was not ok (${response.status})`);
    }
    return response.json();
  });
}

// sends customer name via GET request
function sendCustomer(firstName, lastName) {
  return fetch(`/api/searchCustomer/${firstName}/${lastName}`).then(response => 
   {
    if (!response.ok) {
      const RESULTS_AREA = document.getElementById("searchResultsArea");
      RESULTS_AREA.innerHTML = `Customber not found`;

      throw new Error(`Network response was not ok (${response.status})`);

    }
    return response.json()})
         
  .then(customer => {
    if (customer === null)
    {
      const RESULTS_AREA = document.getElementById("searchResultsArea");
      RESULTS_AREA.innerHTML = ``;
      RESULTS_AREA.innerHTML = `Customer not found`

    }
    else {
      const RESULTS_AREA = document.getElementById("searchResultsArea");
      RESULTS_AREA.innerHTML = `<h3> Customer found:<br><ul><li>First Name: ${customer.firstName}</li><li>Last Name ${customer.lastName}</li><li>Balance: ${customer.balance}</li></ul>`;
  
  }
});
  
}
