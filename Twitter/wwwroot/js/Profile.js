
    //$(document).ready(function () {
    //    $("button").click(function () {
    //        // Change text of button element
    //        $("#flw").html("Unfollow").click(function () {
    //            // Change text of button element
    //            $("#flw").html("Follow");
    //        });
    //    });
    //    });
    
function Follow(){
    $.ajax({
        type: "POST",
        url: "/Twitter/Follow",
        success: function (response){
            if (response) {
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
    
function UnFollow(){
    $.ajax({
        type: "POST",
        url: "/Twitter/UnFollow",
        success: function (response) {
            if (response) {

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
      

 function gotoHome() {
         location.href = "/Twitter/Home";
  }



src = "https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"
src = "~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"