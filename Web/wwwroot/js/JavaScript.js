function sendMail() {
    Email.send({
        Host: "us2.smtp.mailhostbox.com",
        Port: "25",
        Username: "hr@enghous.com",
        Password: "HR123456789",
        To: 'khilel208@gmail.com',
        From: "hr@enghous.com",
        Subject: "TEST mail",
       
        Body: "<html><h2>Thanks alot </h2><strong>Dear : " + document.getElementById("name").value + "  </strong><br></br><em>We Got Your meassage and saved in our databse</em></html>" + document.getElementById("name").value + "/" + document.getElementById("email").value + "/" + document.getElementById("phone").value + "/" + document.getElementById("message").value,
        Attachments: [
            {
                name: "smtpjs.png",
                path: "https://networkprogramming.files.wordpress.com/2017/11/smtpjs.png"

            }] 
       
       
      

    })
        .then(function (message) {
            alert("Mail has been sent successfully")
        });
}
function sendMail1() {
    Email.send({
        Host: "us2.smtp.mailhostbox.com",
        Port: "25",
        Username: "hr@enghous.com",
        Password: "HR123456789",
        To: 'khilel208@gmail.com,'+document.getElementById("email1").value+'', 
        From: "hr@enghous.com",
        Subject: "EHC Team",
        Body: "<html><h2>Thanks alot </h2><strong>Dear : " + document.getElementById("name1").value + "</strong><br></br><em>We Got Your meassage and will  contact you  on email and phone below : </em><br><br><hr><mark>" + document.getElementById("email1").value + "<br><br>" + document.getElementById("phone1").value + "</mark><br><hr>Message Details: <br><br><cite>" + document.getElementById("message1").value + " </cite><br> </html> ",
        Attachments: [
            {
                name: "smtpjs.png",
                path: "https://networkprogramming.files.wordpress.com/2017/11/smtpjs.png"
            }]
    })
        .then(function (message) {
            alert("Mail has been sent successfully")
        });
}
function sendEmail2() {
    Email.send({
        Host: "smtp.gmail.com",
        Username: "Your Gmail Address",
        Password: "Your Gmail Password",
        To: 'it@enghous.com, recipient_2_email_address',
        From: "sender’s email address",
        Subject: "email subject",
        Body: "email body",
    }).then(
        message => alert("mail sent successfully")
    );
}