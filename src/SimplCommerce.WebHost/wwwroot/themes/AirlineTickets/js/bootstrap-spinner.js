/* ========================================================================
 * Bootstrap: spinner.js v3.1.1
 * http://github.com/indigojs
 * ========================================================================
 * Copyright 2014 Márk Sági-Kazár
 * Licensed under MIT (https://github.com/indigojs/bootstrap-spinner/blob/master/LICENSE)
 * ======================================================================== */

+function ($) {
  'use strict';

  // SPINNER CLASS DEFINITION
  // =========================

  var Spinner = function (element, options) {
    var $this = this;
    this.$element = $(element)
    this.options  = $.extend({}, Spinner.DEFAULTS, this.$element.data(), options)

    // Check for insane values
    var value = new Number(this.$element.val())
    if (isNaN(value)) this.$element.val(this.options.min)

    // Strict check entered value
    if (this.options.strict == true) {
      this.$element.on('keypress', function (e) {
        var prevent = false

        if (e.which == 45 || e.keyCode == 40) {
          $this.decrease()
          return false
        } else if (e.which == 43 || e.keyCode == 38) {
          $this.increase()
          return false
        }

        // Allow: backspace, delete, tab, escape, enter, home, end, left, right
        // Allow: Ctrl+A
        // Allow: home, end, left, right
        // Allow . if precision is gt 0
        if ($.inArray(e.keyCode, [8, 46, 9, 27, 13, 36, 35, 37, 39]) !== -1 ||
            (e.which == 65 && e.ctrlKey === true) ||
            ($this.options.precision > 0 && $this.$element.val().indexOf('.') == -1 && e.which == 46)) {
                 return
        }

        // Ensure that it is a number and stop the keypress
        if (e.which < 48 || e.which > 57) return false
      });

      // Validate after focus lost
      this.$element.on('blur', function (e) {
        $this.change($this.$element.val())
      })
    }
  }

  Spinner.DEFAULTS = {
    step: 1,
    min: 0,
    max: Infinity,
    precision: 0,
    strict: true
  }

  Spinner.prototype.increase = function() {
    this.step(this.options.step)
  }

  Spinner.prototype.decrease = function() {
    this.step(-this.options.step)
  }

  Spinner.prototype.step = function (value) {
    if (typeof value !== 'number') value = new Number(value)
    if (isNaN(value)) return

    var current = new Number(this.$element.val())
    if (isNaN(current)) current = this.options.min

    this.change(current + value)
  }

  Spinner.prototype.change = function(value) {
    if (typeof value !== 'number') value = new Number(value)
    if (isNaN(value)) value = this.options.min

    if (value < this.options.min) value = this.options.min
    if (value > this.options.max) value = this.options.max

    var e = $.Event('change.bs.spinner', { value: value })
    this.$element.trigger(e)

    e = $.Event('changed.bs.spinner')

    this.$element.val(value.toFixed(this.options.precision)).change().trigger(e)
  }

  Spinner.prototype.setOptions = function(options) {
    if (typeof options == 'object') this.options = $.extend({}, this.options, options)
  }

  // SPINNER PLUGIN DEFINITION
  // =========================

  var old = $.fn.spinner

  $.fn.spinner = function (option, arg) {
    return this.each(function () {
      var $this   = $(this)
      var data    = $this.data('bs.spinner')
      var isNew   = (typeof data == 'object')
      var options = typeof option == 'object' && option

      if (!data) $this.data('bs.spinner', (data = new Spinner(this, options)))

      if (typeof option == 'object' && isNew == false) data.setOptions(option)
      else if (typeof option == 'number') data.step(option)
      else if (typeof option == 'string') data[option](arg)
    })
  }

  $.fn.spinner.Constructor = Spinner

  // SPINNER NO CONFLICT
  // ===================

  var trigger = function (event) {
    var $this   = $(this)
    var href    = $this.attr('href')
    var $target = $($this.attr('data-target') || (href && href.replace(/.*(?=#[^\s]+$)/, ''))) //strip for ie7
    var value   = $this.data('value')

    if ($this.is('a')) event.preventDefault()

    $target.spinner(value)
  }

  $.fn.spinner.noConflict = function () {
    $.fn.spinner = old
    return this
  }

  // SPINNER DATA-API
  // ================

  $(document)
    .on('click.bs.spinner.data-api', '[data-toggle="spinner"][data-on!="mousehold"]', trigger)
    .on('mousehold.bs.spinner.data-api', '[data-toggle="spinner"]', trigger)

  $(window).on('load', function () {
    $('[data-ride="spinner"]').each(function () {
      $(this).spinner()
    })
  })

}(jQuery);
