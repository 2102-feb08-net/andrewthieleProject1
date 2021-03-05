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
  // const customers =  [
  //   {
  //     id: '1',
  //     fname: 'Bob',
  //     lname: 'Smith'
  // },
  // {id: '2',
  //   fname: 'John',
  //   lname: 'Jackson'
  // },
  // {id: '3',
  //   fname: 'Elvis',
  //   lname: 'Presly'
  // },
  // ];

  return fetch(`/api/customers`).then(response => {
    if(!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
    return response.json();
  });

  // const anchor = document.getElementById('customerList');
  
  // for(const customer of customers) {
  //   debugger;
  //   anchor.appendChild(new Option(`${customer.fname} ${customer.lname}`,`${customer.id}`));
  // }
  
}

//LoadCustomerList();

function LoadLocationList() {
  // const locations = [
  //   {
  //     storeCode: 'OKCI1'
  //   },    
  //   {
  //     storeCode: 'CHIC5'
  //   },    
  //   {
  //     storeCode: 'LAS1'
  //   },    
  //   {
  //     storeCode: 'KC10'
  //   },    
  // ];

  // const anchor = document.getElementById('LocationList');
  // for(const location of locations) {
  //   debugger;
  //   anchor.appendChild(new Option(`${location.storeCode}`));
  // }

  return fetch(`/api/locations`).then(response => {
    if(!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
    return response.json();
  });
}

//LoadLocationList();


function LoadProductList() {
  // const products =  [
  //   {
  //     name: 'hip-hop-a-bot-a-mus'
  //   },    
  //   {
  //     name: 'fish'
  //   },    
  //   {
  //     name: 'pony'
  //   },    
  // ];

  // const anchor = document.getElementById('ProductList');
  // for(const product of products) {
  //   anchor.appendChild(new Option(`${product.name}`,`${product.name}`));
  // }
  return fetch(`/api/products`).then(response => {
    if(!response.ok) {
      throw new Error(`Network response was not ok (${response.status})`);
    }
    return response.json();
  });

}

//LoadProductList();

function LoadOrderList() {
  const orders =  [
    {
      ID: '1',
      Customer: 'Bob Smith',
      Location: 'X'
    },    
    {
      ID: '2',
      Customer: 'Bob Smith',
      Location: 'Y'
    },    
    {
      ID: '3',
      Customer: 'Bob Smith',
      Location: 'Z'    },    
  ];

  const anchor = document.getElementById('orderList');
  for(const order of orders) {
    anchor.appendChild(new Option(`${order.Customer} - ${order.ID}`,`${order.ID}`));
  }
}

//LoadOrderList();

function LoadListsForOrders() {
  LoadProductList();
  LoadLocationList();
  LoadCustomerList();
}