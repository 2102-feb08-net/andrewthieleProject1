'use strict';

const anchor = document.getElementById('customerList');



LoadCustomerList().then(customers => {
  debugger;
  for (const customer of customers) {
    anchor.appendChild(new Option(`${customer.firstName} ${customer.lastName}`,`${customer.id}`));

  }

});