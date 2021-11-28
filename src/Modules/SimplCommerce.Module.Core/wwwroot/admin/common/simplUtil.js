; (function (name, root, factory) {
    if (typeof exports === 'object') {
        module.exports = factory();
    }
    else if (typeof define === 'function' && define.amd) {
        define(factory);
    }
    else {
        root[name] = factory();
    }
}('simplUtil', this, function () {

    function escapeHtml(source) {
        if (source == null) {
            source = '';
        }

        return source
            .replace(/&/g, '&amp;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;');
    }

    return {
        escapeHtml: escapeHtml
    };
}))
