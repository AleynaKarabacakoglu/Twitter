
    function Post() {
        let Tweet = $("#TwitterText").val();       
        let newTweet = {
            Text: Tweet,            
        };
        $.ajax({
        type: "POST",
            url: "/Twitter/PostControl",
            data: newTweet,
            //dataType :"Json",
            success: function (response) {
                if (response) {
                 location.href = "/Twitter/Home"
                    console.log("İşlem Başarılı");
                }
                else {
                    alert("Hata");
                    location.href = "/Twitter/Home"
                }
            },
            error: function () {

               console.log("Hata Oluştu");
            }
        });
}

function GetMyProfile() {  
    $.ajax({
        type: "POST",
        url: "/Twitter/GetMyProfile",    
        success: function (response) {            
            if (response) {
                location.href = "/Twitter/Profile"
                console.log("İşlem Başarılı");
            }
            else {
                alert("Hata");
                location.href = "/Twitter/Home"
            }
        },
        error: function () {

            console.log("Hata Oluştu");
        }
    });
}
function redirect() {
    location.href = "/Account/SignOut";
}

function ProfilePosts() {
    let profile = $("#SearchProfile").val();
    //let obj = HttpContext.Session.GetObject("User");

    let user = {
        Username: profile,
    };

    $.ajax({
        type: "POST",
        url: "/Twitter/ProfileControl",
        data: user,
        //dataType :"Json",
        success: function (response) {
            if (response) {
                location.href = "/Twitter/Profile"
                console.log("İşlem Başarılı");
            }
            else {
                alert("Hata");
                location.href = "/Twitter/Home"
            }

        },
        error: function () {

            console.log("Hata Oluştu");
        }
    });
}


 src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"
 src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"
