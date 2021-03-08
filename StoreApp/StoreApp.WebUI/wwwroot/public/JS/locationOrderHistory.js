'use strict';

const anchor = document.getElementById("LocationList");

const GET_LOCATION_HISTORY_DATA = document.getElementById("actionBtn");

LoadLocationList().then(locations => {
  for (const location of locations) {
    anchor.appendChild(new Option(`${location.code} `,`${location.id}`));
  }
  return;
});

GET_LOCATION_HISTORY_DATA.addEventListener("click", () => {
  const whichLocationID = document.getElementById("LocationList").value;

  // HeyYouGuys(whichLocationID);

  const DISPLAY_AREA = document.getElementById("Location Order History");

  DisplayLocationOrders(whichLocationID);

});

function DisplayLocationOrders(whichLocationId) {
  // HeyYouGuys(whichLocationId);
  
  const DISPLAY_AREA = document.getElementById("Location Order History");
  DISPLAY_AREA.innerHTML = ``;
  return fetch(`/api/order/location/${whichLocationId}`).then(response => {
    if(!response.ok) {
      DISPLAY_AREA.innerHTML = `Network response was not ok()${response.status}`;
      throw new Error(`Network response was not ok()${response.status}`);
    }
    
    return response.json();
  }).then(orderhistory => {
    if(orderhistory.length === 0)
    {
      DISPLAY_AREA.innerHTML = `THIS LOCATION HAS NO ORDERS`;
      return;
    } else {
      DISPLAY_AREA.innerHTML = ``;

      orderhistory.forEach(element => {
        if (element === null) {

        }
        let row = document.createElement("p");
        row.innerHTML = `Order ID: ${element.id} Cusstomer ID: ${element.customerId}`;
        DISPLAY_AREA.appendChild(row);
        element.orderItems.forEach(orderedItem => {
          let orderedItemRow = document.createElement("p");
          orderedItemRow.innerHTML = `PRODUCT ID: ${orderedItem.productId} QUANTITY: ${orderedItem.quantity}`;
          DISPLAY_AREA.appendChild(orderedItemRow);
        })
      });
    }
  });

}

