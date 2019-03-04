$().ready(function () {
    $("#signupForm").validate({
        rules: {
            First: {
                required: true
            },
            Last: {
                required: true
            },
            Password: {
                required: true,
                minlength: 3
            },
            ConfirmPassword: {
                required: true,
                minlength: 3,
                equalTo: "#Password"
            },
            Mobile: {
                required: true,
                number: true
            },
        },
        messages: {
            First: {
                required: "Please Enter Your First Name",
            },
            Last: {
                required: "Please Enter Your Last Name",
            },
            Password: {
                required: "Please Provide a Password",
                minlength: "Your Password Must Be AtLeast 3 Characters Long",
            },
            ConfirmPassword: {
                required: "Please Provide a Password",
                minlength: "Your Password Must Be AtLeast 3 Characters Long",
                equalTo: "Please Enter The Same Password as Above"
            },
            Mobile: {
                required: "Please Enter a valid Mobile Number",
                
            },
        }
    });
    jQuery.validator.addMethod("number", function (value, element) {
        return this.optional(element) || /^.+if(!$.isNumeric(value))$/.test(value);
    }, "Only Numiric Numbers Are Allowed.");
});
