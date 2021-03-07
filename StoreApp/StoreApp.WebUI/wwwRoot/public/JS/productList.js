'use strict';

const anchor = document.getElementById('productList');

LoadProductList().then(products => {
  // debugger;
  for(const product of products) {
    anchor.appendChild(new Option(`${product.name}`,`${product.id}`))
  }
});