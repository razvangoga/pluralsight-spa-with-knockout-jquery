﻿define('ko.utils',
['ko'],
function (ko) {

    ko.utils.wrapAccessor = function (accessor) {
        return function () {
            return accessor;
        };
    };

});