"using strict"

import { getNext } from "./TourAPI.js";

var button = document.getElementById("tourButton");
button.addEventListener("click", function(e){
    var result1 = getNext();
    console.log(result1);
})


