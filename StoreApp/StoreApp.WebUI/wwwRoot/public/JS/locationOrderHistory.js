'use strict';
const anchor = document.getElementById("LocationList");

const GET_LOCATION_HISTORY_DATA = document.getElementById("actionBtn");

LoadLocationList().then(locations => {
  for (const location of locations) {
    anchor.appendChild(new Option(`${location.code} `,`${location.id}`));
  }

});