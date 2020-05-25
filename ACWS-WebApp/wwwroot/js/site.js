// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const uri = "/api/submission"

async function redeemCode() {
    var success_box = document.getElementById('success_box');
    success_box.style.visibility = 'hidden';
    success_box.style.position = 'absolute';
    
    var failed_box = document.getElementById('failed_box');
    failed_box.style.visibility = 'hidden';
    failed_box.style.position = 'absolute';

    var serial_number = document.getElementById('serial_number');
    var fname = document.getElementById('fname');
    var lname = document.getElementById('lname');
    var email = document.getElementById('email');
    var dob = document.getElementById('dob');
    var tos_pp = document.getElementById('tos_pp');
    
    var tos_pp_bool = false;
    if (tos_pp.value == "on") {
        tos_pp_bool = true;
    }

    const submission = {
        SerialKey: serial_number.value,
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
        serial_number.value = "";
        success_box.style.visibility = 'visible';
        success_box.style.position = 'relative';
    }
    else {
        failed_box.style.visibility = 'visible';
        failed_box.style.position = 'relative';
    }
}

function getCookieFieldValue(keyName) {
    var decodedCookie = decodeURIComponent(document.cookie);
    var cookieArray = decodedCookie.split(';');

    var result;
    cookieArray.forEach(cookie => {
        var kv = cookie.split('=');
        if (kv[0] == keyName) {
            console.warn(kv[1]);
            result = kv[1];
        }
    });

    return result;
}

async function getEntries(prizePoolID) {
    var participantID = getCookieFieldValue("ParticipantID");

    if (participantID > 0) {

        const entriesRequest = {
            PrizePoolID: prizePoolID,
            ParticipantID: participantID
        }

        var new_uri = uri + "/getentries";
        let response = await fetch(new_uri, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(entriesRequest)
        })

        if (response.ok) {
            return await response.text();
        }
    }
}

async function getEntriesLeft() {
    var participantID = getCookieFieldValue("ParticipantID");

    if (participantID > 0) {

        const entriesRequest = {
            ParticipantID: participantID
        }

        var new_uri = uri + "/entriesleft";
        let response = await fetch(new_uri, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(entriesRequest)
        })

        if (response.ok) {
            return await response.text();
        }
    }
}

async function useEntry(prize_pool) {
    var participantID = getCookieFieldValue("ParticipantID");
    var prizePoolID = prize_pool.id;

    const entriesRequest = {
        PrizePoolID: prizePoolID,
        ParticipantID: participantID
    }

    var new_uri = uri + "/useentry";
    let response = await fetch(new_uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(entriesRequest)
    })

    if (response.ok) {
        prize_pool.className = "btn btn-success w-100";
        prize_pool.innerHTML = "Added Entry!";

        var entries = document.getElementById(("entries" + prizePoolID));
        entries.innerHTML = await getEntries(prize_pool.id);

        var entriesLeft = await getEntriesLeft();
        document.getElementById("entriesLeft").innerHTML = entriesLeft;

        if (entriesLeft < 1) {
            prize_pool.setAttribute("href", "/Home/Redeem");
            prize_pool.className = "btn btn-primary w-100";
            prize_pool.innerHTML = 'Redeem codes to enter';
        }
        else {
            setTimeout(function() {
                prize_pool.className = "btn btn-primary w-100";
                prize_pool.innerHTML = '1 x <img src="../img/coin-icon-selfmade.png" class="ent-icon">';
                
            }, 500);
        }
    }
}

function checkSerialNumber() {
    var serial_number = document.getElementById('serial_number');
    var snErrorMsg = document.getElementById('snErrorMsg');

    if (/^([a-zA-Z0-9]*)$/.test(serial_number.value)) {
        snErrorMsg.style.visibility = 'hidden';
    }
    else {
        snErrorMsg.style.visibility = 'visible';
    }
}

function checkFName() {
    var fname = document.getElementById('fname');
    var fnameErrorMsg = document.getElementById('fnameErrorMsg');

    if (/^([a-zA-Z]*)$/.test(fname.value)) {
        fnameErrorMsg.style.visibility = 'hidden';
    }
    else {
        fnameErrorMsg.style.visibility = 'visible';
    }
}

function checkLName() {
    var lname = document.getElementById('lname');
    var lnameErrorMsg = document.getElementById('lnameErrorMsg');

    if (/^([a-zA-Z]*)$/.test(lname.value)) {
        lnameErrorMsg.style.visibility = 'hidden';
    }
    else {
        lnameErrorMsg.style.visibility = 'visible';
    }
}

function checkDOB() {
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

function checkTOS_PP() {
    var tos_pp = document.getElementById('tos_pp');
    var tos_ppErrorMsg = document.getElementById('tos_ppErrorMsg');

    if (tos_pp.checked) {
        tos_ppErrorMsg.style.visibility = 'hidden';
    }
    else {
        tos_ppErrorMsg.style.visibility = 'visible';
    }
}