function matchpass() {
    var pw0 = document.getElementById('0').value;
    var pw1 = document.getElementById('1').value;
    var pw2 = document.getElementById('2').value;
    if (pw0 == '') {
        alert("Bạn chưa nhập mật khẩu hiện tại!");
        return false;
    }
    else
    {
        if (pw1 == '') {
            alert("Bạn chưa nhập mật khẩu mới!"); return false;
        }
        else
        {
            if (pw2 == '') {
                alert("Bạn chưa nhập lại mật khẩu mới!");
                return false;
            }
            else {

                if (pw1 != pw2) {
                    alert("Mật khẩu không khớp!");
                    return false;

                }
                else


                    return true;
            }
            
        }
        

    }
        //alert("Đổi mật khẩu thành công!")

}


function matchinfor()
{
    var name = document.getElementById('namegv').value;
    var phone = document.getElementById('phonegv').value;
    var sex = document.getElementById('sexgv').value;
    var diachi = document.getElementById('diachigv').value;
    var trinhdo = document.getElementById('trinhdogv').value;
    var trangthai = document.getElementById('trangthaigv').value;
    var filter = /^([a-zA-Z0-9_\.\-])+\ @(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (name == "")
    {
        alert("Chưa nhập họ tên");
        return false;
    }
                
    if (sex == "")
    {
        alert("Chưa nhập giới tính");
        return false;
    }
        
    if (phone == "" || phone != "" && Number.isNaN(phone) == false)
    {
                alert("Nhập lại số điện thoại");
                return false;
    }
    if (diachi == "")
    {
        alert("Chưa nhập địa chỉ");
        return false;
    }
       
    if (trinhdo == "")
    {
        alert("Chưa nhập trình độ");
        return false;
    }
       
    if (trangthai == "")
    {
        alert("Chưa nhập trạng thái");
        return false;
    }
        
    if (!filter.test(email))
    {
        alert("Hãy nhập địa chỉ mail hợp lệ.\nExample@gmail.com");
        email.focus;
        return false;
    }

    else
    {
        alert("dữ liệu ok");
        return true;
    }
}
function matchinfor1()
{
    var name = document.getElementById('namegv').value;
    var phone = document.getElementById('phonegv').value;
    var sex = document.getElementById('sexgv').value;
    var diachi = document.getElementById('diachigv').value;
    var filter = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (name == '') {
        alert("Chưa nhập họ tên");
        return false;
    }
    else {
        if (sex == '') {
            alert("Chưa nhập giới tính");
            return false;
        }
        else {
            if (phone == '' || phone != '' && Number.isNaN(phone) == false) {
                alert("Nhập lại số điện thoại");
                return false;
            }
            else {
                if (diachi == '') {
                    alert("Chưa nhập địa chỉ");
                    return false;
                }
                else {
                    if (!filter.test(email.value)) {
                        alert("Hãy nhập địa chỉ mail hợp lệ.\nExample@gmail.com");
                        email.focus;
                        return false;
                    }
                    else
                    return false;
                }
                
            }
            
        }
        
    }
    
}

function uagidayta()
{
    
    var email = document.getElementById('email').value;
    var phone = document.getElementById('phonegv').value;
    var filter = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (!filter.test(email))
    {
        alert("Hãy nhập địa chỉ mail hợp lệ.\nExample@gmail.com");
        email.focus;
        return false;
    }
    else
    {

        return true;
    }
}
function botdiche() {
    
    var email = document.getElementById('email').value;
    var filter = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
   
    if (!filter.test(email)) {
        alert("Hãy nhập địa chỉ mail hợp lệ.\nExample@gmail.com");
        email.focus;
        return false;
    }
    
    else {

        return true;
    }
}
     

