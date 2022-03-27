// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Below Should be the less than ideal filter approach
//Reason calling an api to query some data is completely un-necessary when the data is not likely to change

$(function () {
    let btnSearchElement = document.getElementById("btnSearch");
    btnSearchElement.addEventListener('click', function () {
        let id = document.getElementById("weaponId").value;
        let name = document.getElementById("weaponName").value;
        let category = document.getElementById("weaponCategory").value;
        let damageType = document.getElementById("weaponDamage").value;

        let request = {
            id: parseInt(id),
            name: name,
            category: parseInt(category),
            damageType: parseInt(damageType),
        };
        try {
            $.ajax({
                type: "POST",
                url: "/Index?handler=SearchBy",
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                data: JSON.stringify(request),
            }).done(function (data) {
                console.log("Found");
                BuildWeaponsTable(data);
            }).fail(function (data) {
                console.error("Not Found" + data.responseText);
            });

        } catch (ex) {
            console.error(ex);
        }

    });
});

function BuildWeaponsTable(data) {
    $(function () {
        try {
            let tableHtml = "";
            $.each(data, function (i, item) {
                tableHtml += '<tr><td>'
                    + item.id + '</td><td>'
                    + item.name + '</td><td>'
                    + item.description + '</td><td>'
                    + item.category + '</td><td>'
                    + item.attackPoints + '</td><td>'
                    + item.defensePoints + '</td><td>'
                    + '<button id="btnWeaponDetails" type="submit" class="btn btn-info">View Details</button>'+ '</td></tr>';
            });

            $('#tblWeaponsBody').html(tableHtml);
        }
        catch (ex) {
            console.error(ex);
        }
    })
};
// Below Should be the ideal filter approach
//Reason this is ideal is because the data has already been loaded on to the page.
// If the data has a low expecation to change there is no reason to call and api and do a database query


$(document).ready(function () {

    $("#weaponName").on("keyup", function () {
        let filterValue = $(this).val().toLowerCase();
        filterWeaponTable(filterValue);
    });

    $("#description").on("keyup", function () {
        let filterValue = $(this).val().toLowerCase();
        filterWeaponTable(filterValue);
    });

    $("#attkPoints").on("keyup", function () {
        let filterValue = $(this).val().toLowerCase();
        filterWeaponTable(filterValue);
    });

    $("#dfsPoints").on("keyup", function () {
        let filterValue = $(this).val().toLowerCase();
        filterWeaponTable(filterValue);
    });

    $("#weaponCategory").on("change", function () {
        let filterValue = $(this).val().toLowerCase();
        filterWeaponTable(filterValue);
    });
});

function filterWeaponTable(filterValue) {
    $("#tblWeaponsBody tr").filter(function () {
        $(this).toggle($(this).text()
            .toLowerCase().indexOf(filterValue) > -1)
    });
}