'use strict';
var underscore = angular.module('underscore', []);
underscore.factory('_', ['$window', function ($window) {
    return $window._;
}]);

var TragateUser = angular.module('TragateUser', ['underscore', 'ngSanitize']);

TragateUser.factory('Variables', function () {
    return {
        isMobile: $(window).width() < 1000 ? (/android|webos|iphone|ipad|ipod|blackberry|iemobile|opera mini/i.test(navigator.userAgent.toLowerCase()) || $(window).width() <= 850) : false,
        emailPattern: /^[-a-z0-9~!$%^&*_=+}{\'?]+(\.[-a-z0-9~!$%^&*_=+}{\'?]+)*@([a-z0-9_][-a-z0-9_]*(\.[-a-z0-9_]+)*\.(aero|arpa|biz|com|coop|edu|gov|info|int|mil|museum|name|net|org|pro|travel|mobi|[a-z][a-z])|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,5})?$/i,
        phonePattern: /^[0-9]*$/,
    }
});

TragateUser.filter("htmlSafe", ['$sce', function ($sce) {
    return function (htmlCode) {
        return $sce.trustAsHtml(htmlCode);
    };
}]);

TragateUser.directive('capitalizeFirst', function ($parse) {
    return {
        require: 'ngModel',
        link: function (scope, element, attrs, modelCtrl) {
            var capitalize = function (inputValue) {
                if (inputValue === undefined) {
                    inputValue = '';
                }
                var capitalized = inputValue.charAt(0).toUpperCase() + inputValue.substring(1);
                if (capitalized !== inputValue) {
                    modelCtrl.$setViewValue(capitalized);
                    modelCtrl.$render();
                }
                return capitalized;
            }
            modelCtrl.$parsers.push(capitalize);
            capitalize($parse(attrs.ngModel)(scope));
        }
    };
});

TragateUser.filter('capitalize', function () {
    return function (input, all) {
        var reg = (all) ? /([^\W_]+[^\s-]*) */g : /([^\W_]+[^\s-]*)/;
        return (!!input) ? input.replace(reg, function (txt) {
            return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();
        }) : '';
    }
});

TragateUser.factory('quotesService', ['$http', function ($http) {
    return {
        buyer: function (data) {
            return $.ajax({method: 'POST',url: '/user/getbuyer-quotes',data: data,headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=utf-8' }})
                .then(function (response) {
                    return response;
                });
        },

        seller: function (data) {
            return $.ajax({method: 'POST',url: '/user/getseller-quotes',data: data,headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=utf-8' }})
                .then(function (response) {
                    return response;
                });
        },

        companyBuyer: function (data) {
            return $.ajax({method: 'POST',url: '/companyadmin/getbuyer-quotes',data: data,headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=utf-8' }})
                .then(function (response) {
                    return response;
                });
        },

        companySeller: function (data) {
            return $.ajax({method: 'POST',url: '/companyadmin/getseller-quotes',data: data,headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=utf-8' }})
                .then(function (response) {
                    return response;
                });
        },

        getQuote: function (data) {
            return $.ajax({method: 'POST',url: '/quote/view-quotation',data: data,headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=utf-8' }})
                .then(function (response) {
                    return response;
                });
        },

        getQuoteHistory: function (data) {
            return $.ajax({method: 'POST',url: '/quote/quotation-history',data: data,headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=utf-8' }})
                .then(function (response) {
                    return response;
                });
        },

        getQuoteProduct: function (data) {
            return $.ajax({method: 'POST',url: '/quote/quotation-product',data: data,headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=utf-8' }})
                .then(function (response) {
                    return response;
                });
        },

        createQuotationHistory: function (data) {
            return $.ajax({method: 'POST',url: '/quote/create-quotation-history',data: data,headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=utf-8' }})
                .then(function (response) {
                    return response;
                });
        },

        quotationContactStatus: function (data) {
            return $.ajax({method: 'POST',url: '/quote/quotation-contact-status',data: data,headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=utf-8' }})
                .then(function (response) {
                    return response;
                });
        }
    }
    //$.ajax({ method: 'POST', url: '/user/getbuyer-quotes', data: data, headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=utf-8' } })
    //$http.post('/user/getbuyer-quotes', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=utf-8' } })
}]);

TragateUser.controller('MainController', function ($scope, $http, Variables, $timeout) {
    $scope.loading = true;
    angular.element('.tab-buttons').removeClass('ng-hide');
    $scope.Variables = Variables;
    //Safe Apply
    $scope.safeApply = function (fn) {
        var phase = this.$root.$$phase;
        if (phase == '$apply' || phase == '$digest') {
            if (fn && (typeof (fn) === 'function')) {
                fn();
            }
        } else {
            this.$apply(fn);
        }
    };
    $scope.scrollTop = function () {
        $('html,body').animate({ scrollTop: 0 }, 'slow');
    }
})

TragateUser.controller('BuyerController', function ($scope, $http, Variables, $timeout, quotesService, $interval) {
    $scope.Tabs = [
        { name: "All", desc: "The list of all buying requests" },
        { name: "Price", desc: "The list of buying requests waiting for price" },
        { name: "Order", desc: "The list of buying requests waiting for order confirmation", },
        { name: "Payment", desc: "The list of buying requests waiting for payment" },
        { name: "Shipment", desc: "The list of buying requests waiting for delivery" },
        { name: "Completed", desc: "The list of completed buying requests" },
        { name: "Cancelled", desc: "The list of cancelled buying requests" }
    ];
    $scope.diffirentRow = 1;
    $scope.buyerQuotes = {};
    $scope.selectedTab = 1;

    //Get Quote
    $scope.getBuyerQuotes = function (quoteStatusId, page) {
        $scope.loading = true;
        $scope.selectedTab = quoteStatusId;
        //Get Quote History
        quotesService.buyer({ quoteStatusId: quoteStatusId, page: page }).then(function (response) {
            $scope.buyerQuotes[quoteStatusId] = response;
            $scope.buyerQuotes[quoteStatusId].Paging = [];
            $scope.buyerQuotes[quoteStatusId].CurrentPage = page;
            for (var i = 1; i <= response.totalPage; i++) {
                $scope.buyerQuotes[quoteStatusId].Paging.push(i);
            }
            if ($scope.buyerQuotes[quoteStatusId].CurrentPage != page) {
                console.log($scope.buyerQuotes[quoteStatusId].CurrentPage +' -> '+ page);
                $scope.scrollTop();
            }
            $timeout(function () {
                $scope.loading = false;
                $scope.safeApply();
            }, 500);
        });
    }

    //Open Popup
    $scope.OpenBuyerModal = function (item) {
        //buyer user quotation contact status update
        quotesService.quotationContactStatus({
            quoteId: item.id,
            buyerContactStatusId: item.buyerContactStatusId
        });

        quotesService.getQuote({ quoteId: item.id }).then(function (response) {
            $scope.Popup = response;
            $scope.Popup.Config = {};
            $scope.Popup.Config.Title = "View Buying Request";

            $('#BuyerModal').modal('show');
            quotesService.getQuoteHistory({ quoteId: item.id }).then(function (hResponse) {
                $scope.Popup.History = hResponse;
                $scope.safeApply();
                quotesService.getQuoteProduct({ quoteId: item.id }).then(function (pResponse) {
                    $scope.Popup.Products = pResponse;
                    $scope.loading = false;
                    $scope.safeApply();
                    $timeout(function () {
                        $('.messages').scrollTop($('.messages').prop('scrollHeight'));
                    }, 500);
                });
            });
        });
        $('#BuyerModal').unbind();
        $('#BuyerModal').on('hidden.bs.modal', function () {
            $scope.getBuyerQuotes($scope.selectedTab, $scope.buyerQuotes[$scope.selectedTab].CurrentPage);
        });
    }

    //Send Description
    $scope.sendDescription = function (id) {
        var button = angular.element('.QuoteModal button[type=button].btn-primary');
        if ($scope.NewDescription == null || $scope.NewDescription == "" || button.hasClass('loading')) {
            return false;
        }
        button.addClass('loading');
        quotesService.createQuotationHistory({
            QuoteId: id,
            Description: $scope.NewDescription
        }).then(function (response) {
            if (response.success) {
                $scope.NewDescription = null;
                quotesService.getQuoteHistory({ quoteId: id }).then(function (hResponse) {
                    $scope.Popup.History = hResponse;
                    $scope.safeApply();
                    $timeout(function () {
                        $('.messages').scrollTop($('.messages').prop('scrollHeight'));
                        button.removeClass('loading');
                    }, 250);
                });
                toastr["success"](response.message);
                $scope.safeApply();
            }
        });
    }
});

TragateUser.controller('SellerController', function ($scope, $http, Variables, $timeout, quotesService, $interval) {
    $scope.Tabs = [
        { name: "All", desc: "The list of all buying requests" },
        { name: "Lead", desc: "The list of buying requests waiting for price" },
        { name: "Deal", desc: "The list of buying requests waiting for order confirmation", },
        { name: "Order", desc: "The list of buying requests waiting for order processing" },
        { name: "Shipping", desc: "The list of buying requests waiting for delivery" },
        { name: "Completed", desc: "The list of completed buying requests" },
        { name: "Cancelled", desc: "The list of cancelled buying requests" }
    ];
    $scope.diffirentRow = 3;
    $scope.sellerrQuotes = {};
    $scope.selectedTab = 1;

    $scope.getSellerQuotes = function (quoteStatusId, page) {
        $scope.loading = true;
        $scope.selectedTab = quoteStatusId;
        quotesService.seller({ quoteStatusId: quoteStatusId, page: page }).then(function (response) {
            $scope.sellerrQuotes[quoteStatusId] = response;
            $scope.sellerrQuotes[quoteStatusId].Paging = [];
            $scope.sellerrQuotes[quoteStatusId].CurrentPage = page;
            for (var i = 1; i <= response.totalPage; i++) {
                $scope.sellerrQuotes[quoteStatusId].Paging.push(i);
            }
            if ($scope.sellerrQuotes[quoteStatusId].CurrentPage != page) {
                $scope.scrollTop();
            }
            $scope.loading = false;
            $scope.safeApply();
        });
    }

    //Open Popup
    $scope.OpenSellerModal = function (item) {
        //seller user quotation contact status update
        quotesService.quotationContactStatus({
            quoteId: item.id,
            sellerContactStatusId: item.sellerContactStatusId
        });

        quotesService.getQuote({ quoteId: item.id }).then(function (response) {
            $scope.Popup = response;
            $scope.Popup.Config = {};
            $scope.Popup.Config.Title = "View Buying Request";
            $('#SellerModal').modal('show');
            quotesService.getQuoteHistory({ quoteId: item.id }).then(function (hResponse) {
                $scope.Popup.History = hResponse;
                $scope.safeApply();
                quotesService.getQuoteProduct({ quoteId: item.id }).then(function (pResponse) {
                    $scope.Popup.Products = pResponse;
                    $scope.loading = false;
                    $scope.safeApply();
                    $timeout(function () {
                        $('.messages').scrollTop($('.messages').prop('scrollHeight'));
                    }, 500);
                });
            });
        });

        $('#SellerModal').unbind();
        $('#SellerModal').on('hidden.bs.modal', function () {
            $scope.getSellerQuotes($scope.selectedTab, $scope.sellerrQuotes[$scope.selectedTab].CurrentPage);
        });
    }

    //Send Description
    $scope.sendDescription = function (id) {
        var button = angular.element('.QuoteModal button[type=button].btn-primary');
        if ($scope.NewDescription == null || $scope.NewDescription == "" || button.hasClass('loading')) {
            return false;
        }
        button.addClass('loading');
        quotesService.createQuotationHistory({
            QuoteId: id,
            Description: $scope.NewDescription
        }).then(function (response) {
            if (response.success) {
                quotesService.getQuoteHistory({ quoteId: id }).then(function (hResponse) {
                    $scope.Popup.History = hResponse;
                    $scope.safeApply();
                    $timeout(function () {
                        $('.messages').scrollTop($('.messages').prop('scrollHeight'));
                        button.removeClass('loading');
                    }, 250);
                });
                toastr["success"](response.message);
                $scope.NewDescription = null;
                $scope.safeApply();
            }
        });
    }
});

TragateUser.controller('CompanyBuyerController', function ($scope, $http, Variables, $timeout, quotesService, $interval) {
    $scope.Tabs = [
        { name: "All", desc: "The list of all buying requests" },
        { name: "Price", desc: "The list of buying requests waiting for price" },
        { name: "Order", desc: "The list of buying requests waiting for order confirmation", },
        { name: "Payment", desc: "The list of buying requests waiting for payment" },
        { name: "Shipment", desc: "The list of buying requests waiting for delivery" },
        { name: "Completed", desc: "The list of completed buying requests" },
        { name: "Cancelled", desc: "The list of cancelled buying requests" }
    ];
    $scope.diffirentRow = 1;
    $scope.buyerQuotes = {};
    $scope.selectedTab = 1;

    //Get Quote
    $scope.getCompanyBuyerQuotes = function (id, quoteStatusId, page) {
        $scope.loading = true;
        $scope.selectedTab = quoteStatusId;
        //Get Quote History
        quotesService.companyBuyer({ id: id, quoteStatusId: quoteStatusId, page: page }).then(function (response) {
            $scope.buyerQuotes[quoteStatusId] = response;
            $scope.buyerQuotes[quoteStatusId].Paging = [];
            $scope.buyerQuotes[quoteStatusId].CurrentPage = page;
            for (var i = 1; i <= response.totalPage; i++) {
                $scope.buyerQuotes[quoteStatusId].Paging.push(i);
            }
            if ($scope.buyerQuotes[quoteStatusId].CurrentPage != page) {
                $scope.scrollTop();
            }
            $scope.loading = false;
            $scope.safeApply();
        });
    }

    //Open Popup
    $scope.OpenBuyerModal = function (item) {
        //buyer company quotation contact status update
        quotesService.quotationContactStatus({
            quoteId: item.id,
            sellerContactStatusId: item.sellerContactStatusId
        });

        quotesService.getQuote({ quoteId: item.id }).then(function (response) {
            $scope.Popup = response;
            $scope.Popup.Config = {};
            $scope.Popup.Config.Title = "View Buying Request";
            $('#BuyerModal').modal('show');
            quotesService.getQuoteHistory({ quoteId: item.id }).then(function (hResponse) {
                $scope.Popup.History = hResponse;
                $scope.safeApply();
                quotesService.getQuoteProduct({ quoteId: item.id }).then(function (pResponse) {
                    $scope.Popup.Products = pResponse;

                    $scope.loading = false;
                    $scope.safeApply();
                    $timeout(function () {
                        $('.messages').scrollTop($('.messages').prop('scrollHeight'));
                    }, 500);
                });
            });
        });

        $('#BuyerModal').unbind();
        $('#BuyerModal').on('hidden.bs.modal', function () {
            $scope.getCompanyBuyerQuotes($scope.selectedTab, $scope.buyerQuotes[$scope.selectedTab].CurrentPage);
        });
    }

    //Send Description
    $scope.sendDescription = function (id) {
        var button = angular.element('.QuoteModal button[type=button].btn-primary');
        if ($scope.NewDescription == null || $scope.NewDescription == "" || button.hasClass('loading')) {
            return false;
        }
        button.addClass('loading');
        quotesService.createQuotationHistory({
            QuoteId: id,
            Description: $scope.NewDescription
        }).then(function (response) {
            if (response.success) {
                $scope.NewDescription = null;
                quotesService.getQuoteHistory({ quoteId: id }).then(function (hResponse) {
                    $scope.Popup.History = hResponse;
                    $scope.safeApply();
                    $timeout(function () {
                        $('.messages').scrollTop($('.messages').prop('scrollHeight'));
                        button.removeClass('loading');
                    }, 250);
                });
                toastr["success"](response.message);
                $scope.safeApply();
            }
        });
    }
});

TragateUser.controller('CompanySellerController', function ($scope, $http, Variables, $timeout, quotesService, $interval) {
    $scope.Tabs = [
        { name: "All", desc: "The list of all buying requests" },
        { name: "Lead", desc: "The list of buying requests waiting for price" },
        { name: "Deal", desc: "The list of buying requests waiting for order confirmation", },
        { name: "Order", desc: "The list of buying requests waiting for order processing" },
        { name: "Shipping", desc: "The list of buying requests waiting for delivery" },
        { name: "Completed", desc: "The list of completed buying requests" },
        { name: "Cancelled", desc: "The list of cancelled buying requests" }
    ];
    $scope.diffirentRow = 3;
    $scope.sellerrQuotes = {};
    $scope.selectedTab = 1;

    $scope.getCompanySellerQuotes = function (id, quoteStatusId, page) {
        $scope.loading = true;
        $scope.selectedTab = quoteStatusId;
        quotesService.companySeller({ id: id, quoteStatusId: quoteStatusId, page: page }).then(function (response) {
            $scope.sellerrQuotes[quoteStatusId] = response;
            $scope.sellerrQuotes[quoteStatusId].Paging = [];
            $scope.sellerrQuotes[quoteStatusId].CurrentPage = page;
            for (var i = 1; i <= response.totalPage; i++) {
                $scope.sellerrQuotes[quoteStatusId].Paging.push(i);
            }

            if ($scope.sellerrQuotes[quoteStatusId].CurrentPage != page) {
                $scope.scrollTop();
            }
            $scope.loading = false;
            $scope.safeApply();
        });
    }

    //Open Popup
    $scope.OpenSellerModal = function (item) {
        //seller user quotation contact status update
        quotesService.quotationContactStatus({
            quoteId: item.id,
            buyerContactStatusId: item.buyerContactStatusId
        });

        quotesService.getQuote({ quoteId: item.id }).then(function (response) {
            $scope.Popup = response;
            $scope.Popup.Config = {};
            $scope.Popup.Config.Title = "View Buying Request";
            $('#SellerModal').modal('show');
            quotesService.getQuoteHistory({ quoteId: item.id }).then(function (hResponse) {
                $scope.Popup.History = hResponse;
                $scope.safeApply();
                quotesService.getQuoteProduct({ quoteId: item.id }).then(function (pResponse) {
                    $scope.Popup.Products = pResponse;

                    $scope.loading = false;
                    $scope.safeApply();
                    $timeout(function () {
                        $('.messages').scrollTop($('.messages').prop('scrollHeight'));
                    }, 500);
                });
            });
        });

        $('#SellerModal').unbind();
        $('#SellerModal').on('hidden.bs.modal', function () {
            $scope.getCompanySellerQuotes($scope.selectedTab, $scope.sellerrQuotes[$scope.selectedTab].CurrentPage);
        });
    }

    //Send Description
    $scope.sendDescription = function (id) {
        var button = angular.element('.QuoteModal button[type=button].btn-primary');
        if ($scope.NewDescription == null || $scope.NewDescription == "" || button.hasClass('loading')) {
            return false;
        }
        button.addClass('loading');

        quotesService.createQuotationHistory({
            QuoteId: id,
            Description: $scope.NewDescription
        }).then(function (response) {
            if (response.success) {
                quotesService.getQuoteHistory({ quoteId: id }).then(function (hResponse) {
                    $scope.Popup.History = hResponse;
                    $scope.safeApply();
                    $timeout(function () {
                        $('.messages').scrollTop($('.messages').prop('scrollHeight'));
                        button.removeClass('loading');
                    }, 250);
                });
                toastr["success"](response.message);
                $scope.NewDescription = null;
                $scope.safeApply();
            }
        });
    }
});