﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const uri = "/api/submission"

async function redeemCode() {
    var success_box = document.getElementById('success_box');
        success_box.style.visibility = 'hidden';
        success_box.style.position = 'absolute';

    const serial_number = document.getElementById('serial_number');
    const fname = document.getElementById('fname');
    const lname = document.getElementById('lname');
    const email = document.getElementById('email');
    const dob = document.getElementById('dob');
    const tos_pp = document.getElementById('tos_pp');
    
    var tos_pp_bool = false;
    if (tos_pp.value == "on") {
        tos_pp_bool = true;
    }

    const submission = {
        SerialNumber: serial_number.value,
        FirstName: fname.value,
        LastName: lname.value,
        Email: email.value,
        DateOfBirth: dob.value,
        ToSPP: tos_pp_bool
    }

    let response = await fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(submission)
    })

    if(response.ok) {
        var success_box = document.getElementById('success_box');
        success_box.style.visibility = 'visible';
        success_box.style.position = 'relative';
    }
}

function checkSerialNumber(){
    var serial_number = document.getElementById('serial_number');
    var snErrorMsg = document.getElementById('snErrorMsg');

    if (/^([a-zA-Z0-9]*)$/.test(serial_number.value)) {
        snErrorMsg.style.visibility = 'hidden';
    }
    else {
        snErrorMsg.style.visibility = 'visible';
    }
}

function checkFName(){
    var fname = document.getElementById('fname');
    var fnameErrorMsg = document.getElementById('fnameErrorMsg');

    if (/^([a-zA-Z]*)$/.test(fname.value)) {
        fnameErrorMsg.style.visibility = 'hidden';
    }
    else {
        fnameErrorMsg.style.visibility = 'visible';
    }
}

function checkLName(){
    var lname = document.getElementById('lname');
    var lnameErrorMsg = document.getElementById('lnameErrorMsg');

    if (/^([a-zA-Z]*)$/.test(lname.value)) {
        lnameErrorMsg.style.visibility = 'hidden';
    }
    else {
        lnameErrorMsg.style.visibility = 'visible';
    }
}

function checkDOB(){
    var dob = document.getElementById('dob');
    var dobErrorMsg = document.getElementById('dobErrorMsg');

    var bday = new Date(dob.value);
    bday.setHours(0, 0, 0, 0)
    
    var notAfter = new Date();
    notAfter.setFullYear(notAfter.getFullYear() - 18);

    if (bday < notAfter) {
        dobErrorMsg.style.visibility = 'hidden';
    }
    else {
        dobErrorMsg.style.visibility = 'visible';
    }
}

function checkTOS_PP(){
    var tos_pp = document.getElementById('tos_pp');
    var tos_ppErrorMsg = document.getElementById('tos_ppErrorMsg');

    if (tos_pp.checked) {
        tos_ppErrorMsg.style.visibility = 'hidden';
    }
    else {
        tos_ppErrorMsg.style.visibility = 'visible';
    }
}