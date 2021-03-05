'use strict';

const anchor = document.getElementById('customerList');



LoadLocationList().then(locations => {
  debugger;
  for (const location of locations) {
    anchor.appendChild(new Option(`${location.code} `,`${location.id}`));
  }

});