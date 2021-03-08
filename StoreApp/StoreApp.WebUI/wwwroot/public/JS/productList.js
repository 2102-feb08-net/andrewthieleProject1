'use strict';

const anchor = document.getElementById('productList');

LoadProductList().then(products => {
  // 
  for(const product of products) {
    anchor.appendChild(new Option(`${product.name}`,`${product.id}`))
  }
});