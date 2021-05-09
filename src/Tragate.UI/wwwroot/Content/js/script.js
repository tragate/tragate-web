$(function () {
    //İlkay
    setTimeout(function () {
        $("body").removeClass("preload");
    },1000);
    $('[data-toggle="tooltip"]').tooltip();

    Array.prototype.remove = function () {
        var what,
            a = arguments,
            L = a.length,
            ax;
        while (L && this.length) {
            what = a[--L];
            while ((ax = this.indexOf(what)) != -1) {
                this.splice(ax, 1);
            }
        }
        return this;
    };

    $('.hamburger').click(function () {
        if ($(window).scrollTop() > 41 || $(window).width() <= 1024 || location.pathname != "/") {
            $('.MainMenu').removeAttr('style');
            $('.MainMenu').toggleClass('active');
        }
    }).children().click(function (e) {
        e.stopPropagation();
    });

    if ($(window).width() > 1024 && location.pathname == "/") {
        $('.MainMenu').removeAttr('style');
        $('.MainMenu').addClass('active');
    }

    if ($(window).width() <= 550) {
        $('.catSlider').slick();
    } else {
        try {
            $('.catSlider').slick('unslick');
        } catch (err) {
            console.log(err);
        }
    }

    $('li.hasSubMenu').click(function () {
        $(this).toggleClass('active');
    });

    $(window).scroll(function () {
        var scroll = $(window).scrollTop();
        if (scroll > 41) {
            $("body").addClass("scrolled");
            if ($(window).width() > 1024) {
                $('.MainMenu').hide(0);
                $('.MainMenu').removeClass('active');
            } 
        } else {
            $("body").removeClass("scrolled");
            if ($(window).width() > 1024 && location.pathname == "/") {
                $('.MainMenu').removeAttr('style');
                $('.MainMenu').addClass('active');
            }
        }
        
        if (scroll > 200) {
            if (!$('.backToTop').hasClass('show')) {
                $('.backToTop').addClass('active show');
                setTimeout(function () { $('.backToTop').removeClass('active'); }, 2000);
            }
        } else {
            $('.backToTop').removeClass('show');
        }

    });

    $('.backToTop').click(function () {
        $("html, body").stop().animate({ scrollTop: 0 }, 500, 'swing');
    });

    if ($('.tabs').not('.not').length > 0) {
        $('.tabs .tab').click(function () {
            if ($(this).find('a,p').length == 0) {
                var parent = $(this).parent('.tabs');
                parent.find('.tab').removeClass('active');
                $(this).addClass('active');
                var to = $(this).data('to');
                parent.next('.tab-content').find('.content').removeClass('active');
                parent.next('.tab-content').find(to).addClass('active');
            }
        });
    }

    //Validation Defaults
    var errorScroll = false;
    $.validator.setDefaults({
        ignore: [],
        errorElement: "label",
        errorClass: "error",
        errorPlacement: function errorPlacement(error, element) {
            var elm = $(element);
            elm.parents('.form-group').append(error);        
        }
    });

    $.validator.addMethod("password", function (value) {
        return /^[A-Za-z0-9\d=!\-@._*]*$/.test(value)
            //&& /[a-z]/.test(value) // has a lowercase letter
            || /\d/.test(value); // has a digit
    }, function (params, element) {
        return 'Must have at least 1 letter and 1 number';
    });
    $.validator.addMethod("tel", function (value) {
        return /^[\+]?9?0?((5(0[5-7]|[3-5]\d))|([2-4]?\d{2}))?\d{3} ?\d{4}$/.test(value);
    }, function (params, element) {
        return 'Enter valid phone number';
    });
    $.validator.addMethod("notEqual", function (value, element, param) {
        return this.optional(element) || value != param;
    }, "Please update your product title, it can not be as same as category tltle");

    $('form.tragate').find('input[required],select[required],textarea[required]').on('change keyup',function () {
        $(this).valid();
    });

    //Modal
    $('.ShowTrageteModal').click(function () {
        $('#loading').show();
        var data = $(this).data();
        $('#TragateModal .modal-body').load(data.url, function (result) {
            setTimeout(function () {
                $('#TragateModal').modal({ show: true });
                if (typeof data.title != 'undefined') {
                    $('#TragateModal .modal-title').html(data.title);
                }
                $('#TragateModal.modal').find('.entry-header').hide();
                $('#loading').hide();
            }, 1000);
        });
    });

    //Json Serialize
    $.fn.extend({
        serializeFormJSON: function serializeFormJSON(s) {
            var o = {};
            var a = this.serializeArray();
            $.each(a, function () {
                if (o[this.name]) {
                    if (!o[this.name].push) {
                        o[this.name] = [o[this.name]];
                    }
                    o[this.name].push(this.value || '');
                } else {
                    o[this.name] = this.value || '';
                }
            });
            if (s) {
                return JSON.stringify(o);
            } else {
                return o;
            }
        }
    });

    $('form').keyup(function (e) {
        e.preventDefault();
        if (e.keyCode == 13 && $(this).find('.summernote').length == 0) {
            $(this).find('.btn.submit').click();
            return false;
        }
    });
    $('form.tragate').submit(function (e) {
        e.preventDefault();
    });

    $(document).on("click","form.tragate .btn.submit",function(e) {
    //$('form.tragate').find('.btn.submit').click(function (e) {
        var that = {};
        that.btn = $(this);
        if (that.btn.hasClass('loading')) {
            return false;
        }
        that.form = $(this).parents('form.tragate');
        that.type = that.form.attr('method');
        that.url = that.form.attr('action');
        var formData = that.form.data();
        var data = that.form.serializeFormJSON();

        if (!that.form.valid()) {
            var elm = that.form.find('.form-group label.error:visible').first();
            if ((elm.offset().top < $(window).scrollTop() || elm.offset().top > (window.innerHeight + $(window).scrollTop()))) {
                $([document.documentElement, document.body]).animate({
                    scrollTop: elm.offset().top
                }, 500);
            }
            return false;
        }
        that.btn.addClass("loading");
        if (that.form.hasClass('inForm')) {
            iziToast.settings({
                target: 'form.tragate',
                targetFirst: true
            });
        }

        if (that.form.hasClass('ajax')) {
            jQuery.ajax({
                type: that.type,
                url: that.url,
                async: false,
                data: data,
                error: function error() {
                    iziToast.error({message:'Fatal Error !'});
                },
                success: typeof formData.callback !== 'undefined' ? callbacks[formData.callback] : function (response) {
                    if (response !== null) {
                        if (typeof formData.event !== 'undefined') {
                            document.dispatchEvent(new CustomEvent(formData.event, { detail: response }));
                        }
                        if (typeof response.url !== 'undefined' && response.url !== null) {

                            window.location = response.url;

                        } else if (response.success) {
                            if (typeof response.url !== 'undefined' && response.url !== null) {
                                window.location = response.url;
                            } else {

                                iziToast.success({ message: response.message });
                                that.btn.removeClass("loading");
                                if (formData.reload) {
                                    setTimeout(function () {
                                        location.reload();
                                    }, formData.reloadtime);
                                }

                                if (typeof formData.redirect != "undefined") {
                                    setTimeout(function () {
                                        location.href = formData.redirect;
                                    }, formData.redirecttime);
                                }
                            }
                        } else {
                            that.btn.removeClass("loading");
                            if (response.errors != null) {
                                var error = response.errors.join('<br/><br/>');
                            } else {
                                var error = response.message;
                            }
                            iziToast.error({ message: error });
                        }
                    }
                }
            });
        }
    });

    //SelectBox Ajax
    var data = [];
    $('select.ajax').each(function (i, e) {
        data[i] = $(this).data();
        if (typeof data[i].change_to != 'undefined') {
            data[i].change_to = $(data[i].change_to);
        }
        data[i].that = $(this);
        if (data[i].that.hasClass('multiple')) {
            data[i].that.parent('.form-group').append('<div class="selected"></div>');
            data[i].selected = data[i].that.parent('.form-group').find('.selected');
        }
        data[i].val_name = typeof data[i].val_name != 'undefined' ? data[i].val_name : 'value';
        $.ajax({
            method: "Get",
            url: data[i].url
        }).then(function (response) {
            if (response.success) {
                data[i].that.html('<option value="" selected>Select</option>');
                data[i].data = response.data;
                $.each(data[i].data, function (ii, e) {
                    data[i].that.append('<option value="' + e.id + '">' + e[data[i].val_name] + '</option>');
                });
                if (typeof data[i].current_val != 'undefined' && data[i].current_val != '0') {
                    //Multiple
                    if (data[i].that.hasClass('multiple')) {
                        data[i].selectedList = data[i].current_val != "" ? data[i].current_val.toString().split(',') : [];
                        $.each(data[i].selectedList, function (ii, e) {
                            var item = $.grep(data[i].data, function (v) {
                                return v.id == e;
                            })[0];
                            data[i].selected.append('<span>' + item[data[i].val_name] + '<div data-id="' + e + '" data-value="' + item[data[i].val_name] + '" class="close" onclick="removeOption[' + i + '](this,' + item.id + ')">X</div></span>');
                            data[i].that.find('option[value="' + item.id + '"]').remove();
                        });

                        //Add Selected
                        data[i].that.on('change', function () {
                            var option = $(this).find('option:selected');
                            var optionVal = option.val();
                            var item = $.grep(data[i].data, function (v) {
                                return v.id == optionVal;
                            })[0];
                            option.remove();
                            data[i].selectedList.push(optionVal);
                            $(data[i].val_to).val(data[i].selectedList.join(','));
                            data[i].selected.append('<span>' + item[data[i].val_name] + '<div data-id="' + optionVal + '" data-value="' + item[data[i].val_name] + '" class="close" onclick="removeOption[' + i + '](this,' + optionVal + ')">X</div></span>');
                        });

                        //Remove Selected
                        removeOption[i] = function (that, id) {
                            var rData = $(that).data();
                            $(that).parent('span').remove();
                            data[i].selectedList.remove(rData.id.toString());
                            $(data[i].val_to).val(data[i].selectedList.join(','));
                            data[i].that.html('<option value="" selected>Select</option>');
                            $.each(data[i].data, function (ii, e) {
                                if (data[i].selectedList.indexOf(e.id) < 0) {
                                    data[i].that.append('<option value="' + e.id + '">' + e[data[i].val_name] + '</option>');
                                }
                            });
                        };
                    } else {
                        data[i].that.val(data[i].current_val).change();
                    }
                }
            } else {
                alert(res.message);
            }
        });

        //Text To
        if (typeof data[i].to_text != 'undefined') {
            data[i].that.on('change', function () {
                $(data[i].to_text).html($(this).find('option:selected').html());
            });
        }

        //Next SelectBox
        if (typeof data[i].change_to != 'undefined') {
            data[i].that.on('change', function () {
                data[i].that.find('option[value=""]').remove();
                var nextData = data[i].change_to.data();
                nextData.val_name = typeof nextData.val_name != 'undefined' ? nextData.val_name : 'value';
                var val = data[i].that.val();
                if(data[i].change_to.next('.loading').length == 0){
                    data[i].change_to.after('<div class="loading"><div class="bounce1"></div><div class="bounce2"></div><div class="bounce3"></div></div>');
                }else{
                    data[i].change_to.next('.loading').show();
                }
                var loading = data[i].change_to.next('.loading');
                loading.show();
                if (val != '') {
                    $.ajax({
                        method: "GET",
                        url: nextData.url + val
                    }).then(function (response) {
                        if (response.success) {
                            data[i].change_to.html('<option value="" selected>Select</option>');
                            $.each(response.data, function (ii, e) {
                                data[i].change_to.append('<option value="' + e.id + '">' + e[nextData.val_name] + '</option>');
                            });
                            loading.hide();
                            if (typeof nextData.current_val != 'undefined' && nextData.current_val != '-1') {
                                data[i].change_to.val(nextData.current_val);
                            }
                        } else {
                            alert(res.message);
                        }
                    });
                } else {
                    data[i].change_to.html('<option value="">Select</option>');
                }
            });
        }
    });

    $('[type=password]').after('<div class="passToggle">Show</div>');
    $('.passToggle').click(function () {
        if ($(this).prev('input').attr('type') === 'password') {
            $(this).prev('input').attr('type', 'text');
            $(this).text('Hide');
        } else {
            $(this).prev('input').attr('type', 'password');
            $(this).text('Show');
        }
    });

    $(document).on('show.bs.modal', '.modal', function () {
        var zIndex = 1040 + (10 * $('.modal:visible').length);
        $(this).css('z-index', zIndex);
        setTimeout(function () {
            $('.modal-backdrop').not('.modal-stack').css('z-index', zIndex - 1).addClass('modal-stack');
        }, 0);
    });

    var createQuotation = function (data) {
        var modal = $('#ContactSupplierModal');
        $.ajax({
            method: "POST",
            url: '/quote/create-quotation',
            data: data,
            success: function (response) {
                if (response.success) {
                    modal.find('#Thanks').html(response.message);
                    modal.find('.step.s1').slideUp();
                    modal.find('.step.s2').slideUp();
                    modal.find('.step.s3').slideDown();
                    modal.find('.tick').addClass('active');
                } else {
                    var error;
                    if (response.errors !== null) {
                        error = response.errors.join('<br/><br/>');
                    } else {
                        error = response.message;
                    }
                    iziToast.error({ message: error });
                }
            }
        });
    };
    var modalData = {};
    $('.ContactSupplier').on('click', function (e) {
        $('.quickAccess button').unbind();
        var Inputdata = $(this).data();
        var modal = $('#ContactSupplierModal');
        $.ajax({
            method: "POST",
            url: '/quote/contact-supplier',
            data: Inputdata,
            success: function (response) {
                modalData = response;
                modal.find('#CompanyTitle').html(response.companyTitle);
                modal.find('#ProductTitle').html(response.productTitle);
                modal.find('.img_wrapper img').attr('src', response.productImage);
                modal.modal('show');
                modal.on('shown.bs.modal', function () {
                    modal.find('.progress-bar').width('50%');
                });
            }
        });
        modal.on('hidden.bs.modal', function () {
            modal.find('.progress-bar').width('0%');
            modal.find('.step.s1').slideDown();
            modal.find('.step.s2').slideUp();
            modal.find('.step.s3').slideUp();
            $('#UserMessage').val('');
            $('.quickAccess button').unbind();
            if (modal.find('.step.s3').hasClass('reload')) {
                modal.find('.step.s3').removeClass('reload')
                setTimeout(function () {
                    location.reload();
                }, 300);
            }
        });
    });

    $('.step.s1').find('button').on('click', function () {
        $(this).addClass('loading');
        var modal = $('#ContactSupplierModal');
        if (!$('.quoteForm').valid()) {
            $(this).removeClass('loading');
            return false;
        }
        modalData.userMessage = $('#UserMessage').val();
        if (modalData.userAuthenticate) {
            createQuotation(modalData);
            modal.find('.progress-bar').width('100%');
        } else {
            modal.find('.step.s1').slideUp();
            modal.find('.step.s2').slideDown();
            modal.find('.progress-bar').width('100%');
            document.addEventListener('Login', function (e) {
                if (e.detail.success) {
                    createQuotation(modalData);
                    modal.find('.step.s2').slideUp();
                    modal.find('.step.s3').slideDown();
                    modal.find('.step.s3').addClass('reload');
                }
            }, false);
            $('.quickAccess button').on('click', function () {
                var quickForm = $('.quickAccess');
                $(this).addClass('loading');
                if (!quickForm.valid()) {
                    $(this).removeClass('loading');
                    return false;
                }
                var quickData = quickForm.serializeFormJSON();
                modalData.buyerUserEmail = quickData.email;
                modalData.countryId = quickData.CountryId;
                modalData.stateId = quickData.StateId;
                modalData.country = modal.find('select[name=CountryId] option:selected').html();
                createQuotation(modalData);
            });
        }
    });

    document.addEventListener('SignUp', function (e) {
        if (e.detail.success) {
            $.get("/Account/SignUpConfirmation", function (data) {
                window.scrollTo(0, 0);
                $('.container').html(data);
            });
        }else{
            window.scrollTo(0, 0);
        }
    }, false);

    document.addEventListener('CompanyRegister', function (e) {
        if (e.detail.success) {
            $('.progress-bar').animate({
                width: '50%',
            }, {
                duration: 1500,
                complete: function () {
                    $('.step.s2').addClass('active');
                    $.get("/Company/register-confirmed", function (data) {
                        window.scrollTo(0, 0);
                        $('.container form').html(data);
                    });
                }
            });
        }
    }, false);

});
var callbacks = {
    quoteLoginCallback: function (response) {
        var modal = $('#ContactSupplierModal');
        if (response.success) {
            toastr["success"]("Login Succesfull");
        } else {
            if (response.errors != null) {
                var error = response.errors.join('<br/><br/>');
            } else {
                var error = response.message;
            }
            toastr["error"](error);
        }
    }
}


window.fbAsyncInit = function () {
    FB.init({
        appId: '546825665834429',
        cookie: true,
        xfbml: true,
        version: 'v3.2'
    });
};

$.ExternalLogin = {
    registerType: {
        Tragate: 1,
        Facebook: 2,
        Google: 3,
        Linkedin: 4
    },

    loginRequest: function (data) {
        $.ajax({
            url: '/account/external-sign-up',
            type: 'post',
            data: data,
            success: function (response) {
                if (!response.success) {
                    $.each(data, function (i, e) {
                        if ($('#ExternalSignUpModal form').find('input[name=' + i + ']').length > 0) {
                            $('#ExternalSignUpModal form').find('input[name=' + i + ']').val(e);
                        } else {
                            $('#ExternalSignUpModal form').append('<input type="hidden" name="' + i + '" value="' + e + '"/>');
                        }
                    });
                    if (!$('#ExternalSignUpModal').hasClass('show')) {
                        $('#ExternalSignUpModal').modal('show');
                    }
                } else {
                    window.location = response.url;
                }
            }
        });
    }
};

$.GoogleLogin = {
    onLoadCallback: function (s) {
        gapi.load('auth2', function () {
            auth2 = gapi.auth2.init({
                client_id: '314100125627-6uhv5ii5h53si2vo2v5663li8tqvkv80.apps.googleusercontent.com',
                cookiepolicy: 'single_host_origin'
            });
            auth2.attachClickHandler(document.getElementsByClassName('social-login google')[0], {}, $.GoogleLogin.onSignIn, $.GoogleLogin.onFailure);
            //auth2.isSignedIn.listen(signinChanged);
        });

        var signinChanged = function (val) {
            if (val) {
                $.GoogleLogin.onSignIn(auth2.currentUser.get());
            }
        };
    },

    onSignIn: function (googleUser) {
        var profile = googleUser.getBasicProfile();
        var requestData = {
            "email": profile.getEmail(),
            "fullName": profile.getName(),
            "profileImagePath": profile.getImageUrl(),
            "stateId": 0,
            "countryId": 0,
            "registerTypeId": $.ExternalLogin.registerType.Google,
            "externalUserId": profile.getId(),
            "externalUserToken": googleUser.getAuthResponse().id_token
        };
        console.log('Google');
        console.log(requestData);
        $.ExternalLogin.loginRequest(requestData);

    },

    onFailure: function (error) {
        console.log('Google Error :');
        console.log(error);
    },

    signOut: function () {
        var auth2 = gapi.auth2.getAuthInstance();
        auth2.signOut().then(function () {
            document.getElementsByClassName("userContent")[0].innerHTML = '';
            document.getElementsByClassName("userContent")[0].style.display = "none";
            document.getElementById("gSignIn").style.display = "block";
        });
        auth2.disconnect();
    }
};

$.FacebookLogin = {
    Login: function () {
        FB.login(function (response) {
            if (response.status === 'connected') {
                $.FacebookLogin.statusChangeCallback(response);
            }
        }, { scope: 'public_profile,email' });
    },

    statusChangeCallback: function (response) {
        if (response.status === 'connected') {
            $.FacebookLogin.get(response);
        } else {
            console.log('Facebook : Logout');
        }
    },

    get: function (data) {
        var User = {};
        FB.api('/me', 'GET',{ locale: 'en_US', fields: 'id, name, email' }, function (response) {
            User = response;
            FB.api('/me/picture', 'GET', { redirect: "false" }, function (response) {
                var requestData = {
                    "email": User.email,
                    "fullName": User.name,
                    "profileImagePath": response.data.url,
                    "stateId": 0,
                    "countryId": 0,
                    "registerTypeId": $.ExternalLogin.registerType.Facebook,
                    "externalUserId": data.authResponse.userID,
                    "externalUserToken": data.authResponse.accessToken
                };
                $.ExternalLogin.loginRequest(requestData);
            });
        });
    }
};

$.Linkedin = {
    liAuth: function () {
        IN.User.authorize(function (data) {
            $.Linkedin.getProfileData();
        });
    },

    onLinkedInLoad: function () {
        IN.Event.on(IN, "auth", $.Linkedin.getProfileData);
    },

    getProfileData: function () {
        IN.API.Profile("me").fields("id", "first-name", "last-name", "headline", "location", "picture-url", "public-profile-url", "email-address").result($.Linkedin.displayProfileData).error($.Linkedin.onError);
    },

    displayProfileData: function (data) {
        var User = data.values[0];
        var requestData = {
            "email": User.emailAddress,
            "fullName": User.firstName + ' ' + User.lastName,
            "profileImagePath": User.pictureUrl,
            "stateId": 0,
            "countryId": 0,
            "registerTypeId": $.ExternalLogin.registerType.Linkedin,
            "externalUserId": User.id,
            "externalUserToken": User.access_token
        };
        console.log(User);
        $.ExternalLogin.loginRequest(requestData);
    },

    onError: function (error) {
        console.log(error);
    },

    logout: function () {
        IN.User.logout(removeProfileData);
    }
};

setTimeout(function () {
    $.GoogleLogin.onLoadCallback();
}, 500);
