'use strict';

const addCustomerForm = document.getElementById("addCustomerForm");
const reporter = document.getElementById("results");
const actionButton = document.getElementById('actionBtn');
const firstName = document.getElementById("firstName");
const lastName = document.getElementById("lastName");

actionButton.addEventListener('click', function(){
  //debugger;
  if (firstName.value === '' || lastName.value === '')
  {
    HeyYouGuys("Form must be completly filled");
    return;
  }
  NewCustomer();
});


function NewCustomer(e) {
  //e.preventDefault();

  const newCustomer =
  {
      //ID: undefined,
      firstName: document.getElementById('firstName').value,
      lastName: document.getElementById('lastName').value,
      balance: '0.00'
      
  };
  console.log(newCustomer);
  addCustomer(newCustomer);
};

function addCustomer(customer) {
  return fetch('/api/addCustomer', {
      method: 'POST',
      headers: {
          'Content-Type': 'application/json'
      },
      body: JSON.stringify(customer)
  })
      .then(response => {
      if (!response.ok) {
          throw new Error(`Network response was not ok (${response.status})`);
      }
      return response.json();
  });
}