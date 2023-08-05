//asynchronous javascript
$.ajax({
    url: "https://swapi.dev/api/people/"
}).done((result) => {
    let temp = "";
    let iteration = 1;
    $.each(result.results, (key, val) => {
        temp += 
            "<tr>" +
            "<td class='col-1'>"+iteration+"</td>" +
            "<td class='col-3'>"+val.name+"</td>" +
            "<td class='col-1'>"+val.height+"</td>" +
            "<td class='col-1'>"+val.gender+"</td>" +
            "<td class='col-1'>"+val.mass+"</td>" +
            "<td class='col-1'>"+val.eye_color+"</td>" +
            "<td class='col-1'>"+val.hair_color+"</td>" +
            "<td class='col-1'>"+val.skin_color+"</td>" +
            "<td class='col-1'>"+val.birth_year+"</td>" +
            "</tr>";
        iteration++;
    })
    $("#tbodySW").html(temp);
    console.log(temp)
});
