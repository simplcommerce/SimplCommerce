/*
 * Smoothproducts version 2.0.2
 * http://kthornbloom.com/smoothproducts.php
 *
 * Copyright 2013, Kevin Thornbloom
 * Free to use and abuse under the MIT license.
 * http://www.opensource.org/licenses/mit-license.php
 */

(function($) {
	$.fn.extend({
		smoothproducts: function() {

			// Add some markup & set some CSS

			$('.sp-loading').hide();
			$('.sp-wrap').each(function() {
				$(this).addClass('sp-touch');
				var thumbQty = $('a', this).length;

				// If more than one image
				if (thumbQty > 1) {
					var firstLarge,firstThumb,
						defaultImage = $('a.sp-default', this)[0]?true:false;
					$(this).append('<div class="sp-large"></div><div class="sp-thumbs sp-tb-active"></div>');
					$('a', this).each(function(index) {
						var thumb = $('img', this).attr('src'),
							large = $(this).attr('href'),
							classes = '';
						//set default image
						if((index === 0 && !defaultImage) || $(this).hasClass('sp-default')){
							classes = ' class="sp-current"';
							firstLarge = large;
							firstThumb = $('img', this)[0].src;
						}
						$(this).parents('.sp-wrap').find('.sp-thumbs').append('<a href="' + large + '" style="background-image:url(' + thumb + ')"'+classes+'></a>');
						$(this).remove();
					});
					$('.sp-large', this).append('<a href="' + firstLarge + '" class="sp-current-big"><img src="' + firstThumb + '" alt="" /></a>');
					$('.sp-wrap').css('display', 'inline-block');
				// If only one image
				} else {
					$(this).append('<div class="sp-large"></div>');
					$('a', this).appendTo($('.sp-large', this)).addClass('.sp-current-big');
					$('.sp-wrap').css('display', 'inline-block');
				}
			});


			// Prevent clicking while things are happening
			$(document.body).on('click', '.sp-thumbs', function(event) {
				event.preventDefault();
			});


			// Is this a touch screen or not?
			$(document.body).on('mouseover', function(event) {
				$('.sp-wrap').removeClass('sp-touch').addClass('sp-non-touch');
				event.preventDefault();
			});

			$(document.body).on('touchstart', function() {
				$('.sp-wrap').removeClass('sp-non-touch').addClass('sp-touch');
			});

			// Clicking a thumbnail
			$(document.body).on('click', '.sp-tb-active a', function(event) {

				event.preventDefault();
				$(this).parent().find('.sp-current').removeClass();
				$(this).addClass('sp-current');
				$(this).parents('.sp-wrap').find('.sp-thumbs').removeClass('sp-tb-active');
				$(this).parents('.sp-wrap').find('.sp-zoom').remove();

				var currentHeight = $(this).parents('.sp-wrap').find('.sp-large').height(),
					currentWidth = $(this).parents('.sp-wrap').find('.sp-large').width();
				$(this).parents('.sp-wrap').find('.sp-large').css({
					overflow: 'hidden',
					height: currentHeight + 'px',
					width: currentWidth + 'px'
				});

				$(this).addClass('sp-current').parents('.sp-wrap').find('.sp-large a').remove();

				var nextLarge = $(this).parent().find('.sp-current').attr('href'),
					nextThumb = get_url_from_background($(this).parent().find('.sp-current').css('backgroundImage'));

				$(this).parents('.sp-wrap').find('.sp-large').html('<a href="' + nextLarge + '" class="sp-current-big"><img src="' + nextThumb + '"/></a>');
				$(this).parents('.sp-wrap').find('.sp-large').hide().fadeIn(250, function() {

					var autoHeight = $(this).parents('.sp-wrap').find('.sp-large img').height();

					$(this).parents('.sp-wrap').find('.sp-large').animate({
						height: autoHeight
					}, 'fast', function() {
						$('.sp-large').css({
							height: 'auto',
							width: 'auto'
						});
					});

					$(this).parents('.sp-wrap').find('.sp-thumbs').addClass('sp-tb-active');
				});
			});

			// Zoom In non-touch
			$(document.body).on('mouseenter', '.sp-non-touch .sp-large', function(event) {
				var largeUrl = $('a', this).attr('href');
				$(this).append('<div class="sp-zoom"><img src="' + largeUrl + '"/></div>');
				$(this).find('.sp-zoom').fadeIn(250);
				event.preventDefault();
			});

			// Zoom Out non-touch
			$(document.body).on('mouseleave', '.sp-non-touch .sp-large', function(event) {
				$(this).find('.sp-zoom').fadeOut(250, function() {
					$(this).remove();
				});
				event.preventDefault();
			});

			// Open in Lightbox non-touch
			$(document.body).on('click', '.sp-non-touch .sp-zoom', function(event) {
				var currentImg = $(this).html(),
					thumbAmt = $(this).parents('.sp-wrap').find('.sp-thumbs a').length,
					currentThumb = ($(this).parents('.sp-wrap').find('.sp-thumbs .sp-current').index())+1;
				$(this).parents('.sp-wrap').addClass('sp-selected');
				$('body').append("<div class='sp-lightbox' data-currenteq='"+currentThumb+"'>" + currentImg + "</div>");

				if(thumbAmt > 1){
					$('.sp-lightbox').append("<a href='#' id='sp-prev'></a><a href='#' id='sp-next'></a>");
					if(currentThumb == 1) {
						$('#sp-prev').css('opacity','.1');
					} else if (currentThumb == thumbAmt){
						$('#sp-next').css('opacity','.1');
					}
				}
				$('.sp-lightbox').fadeIn();
				event.preventDefault();
			});

			// Open in Lightbox touch
			$(document.body).on('click', '.sp-large a', function(event) {
				var currentImg = $(this).attr('href'),
					thumbAmt = $(this).parents('.sp-wrap').find('.sp-thumbs a').length,
					currentThumb = ($(this).parents('.sp-wrap').find('.sp-thumbs .sp-current').index())+1;

				$(this).parents('.sp-wrap').addClass('sp-selected');
				$('body').append('<div class="sp-lightbox" data-currenteq="'+currentThumb+'"><img src="' + currentImg + '"/></div>');

				if(thumbAmt > 1){
					$('.sp-lightbox').append("<a href='#' id='sp-prev'></a><a href='#' id='sp-next'></a>");
					if(currentThumb == 1) {
						$('#sp-prev').css('opacity','.1');
					} else if (currentThumb == thumbAmt){
						$('#sp-next').css('opacity','.1');
					}
				}
				$('.sp-lightbox').fadeIn();
				event.preventDefault();
			});

			// Pagination Forward
			$(document.body).on('click', '#sp-next', function(event) {
				event.stopPropagation();
				var currentEq = $('.sp-lightbox').data('currenteq'),
					totalItems = $('.sp-selected .sp-thumbs a').length;

					if(currentEq >= totalItems) {
					} else {
						var nextEq = currentEq + 1,
						newImg = $('.sp-selected .sp-thumbs').find('a:eq('+currentEq+')').attr('href'),
						newThumb = get_url_from_background($('.sp-selected .sp-thumbs').find('a:eq('+currentEq+')').css('backgroundImage'));
						if (currentEq == (totalItems - 1)) {
							$('#sp-next').css('opacity','.1');
						}
						$('#sp-prev').css('opacity','1');
						$('.sp-selected .sp-current').removeClass();
						$('.sp-selected .sp-thumbs a:eq('+currentEq+')').addClass('sp-current');
						$('.sp-selected .sp-large').empty().append('<a href='+newImg+'><img src="'+newThumb+'"/></a>');
						$('.sp-lightbox img').fadeOut(250, function() {
							$(this).remove();
							$('.sp-lightbox').data('currenteq',nextEq).append('<img src="'+newImg+'"/>');
							$('.sp-lightbox img').hide().fadeIn(250);
						});
					}

				event.preventDefault();
			});

		// Pagination Backward
			$(document.body).on('click', '#sp-prev', function(event) {

				event.stopPropagation();
				var currentEq = $('.sp-lightbox').data('currenteq'),
					currentEq = currentEq - 1;
					if(currentEq <= 0) {
					} else {
						if (currentEq == 1) {
							$('#sp-prev').css('opacity','.1');
						}
						var nextEq = currentEq - 1,
						newImg = $('.sp-selected .sp-thumbs').find('a:eq('+nextEq+')').attr('href'),
						newThumb = get_url_from_background($('.sp-selected .sp-thumbs').find('a:eq('+nextEq+')').css('backgroundImage'));
						$('#sp-next').css('opacity','1');
						$('.sp-selected .sp-current').removeClass();
						$('.sp-selected .sp-thumbs a:eq('+nextEq+')').addClass('sp-current');
						$('.sp-selected .sp-large').empty().append('<a href='+newImg+'><img src="'+newThumb+'"/></a>');
						$('.sp-lightbox img').fadeOut(250, function() {
							$(this).remove();
							$('.sp-lightbox').data('currenteq',currentEq).append('<img src="'+newImg+'"/>');
							$('.sp-lightbox img').hide().fadeIn(250);
						});
					}
				event.preventDefault();
			});


			// Close Lightbox
			$(document.body).on('click', '.sp-lightbox', function() {
				closeModal();
			});

			// Close on Esc
			$(document).keydown(function(e) {
				if (e.keyCode == 27) {
					closeModal();
					return false;
				}
			});

			function closeModal (){
				$('.sp-selected').removeClass('sp-selected');
				$('.sp-lightbox').fadeOut(function() {
						$(this).remove();
				});
			}


			// Panning zoomed image (non-touch)

			$('.sp-large').mousemove(function(e) {
				var viewWidth = $(this).width(),
					viewHeight = $(this).height(),
					largeWidth = $(this).find('.sp-zoom').width(),
					largeHeight = $(this).find('.sp-zoom').height(),
					parentOffset = $(this).parent().offset(),
					relativeXPosition = (e.pageX - parentOffset.left),
					relativeYPosition = (e.pageY - parentOffset.top),
					moveX = Math.floor((relativeXPosition * (viewWidth - largeWidth) / viewWidth)),
					moveY = Math.floor((relativeYPosition * (viewHeight - largeHeight) / viewHeight));

				$(this).find('.sp-zoom').css({
					left: moveX,
					top: moveY
				});

			});

			function get_url_from_background(bg){
				return bg.match(/url\([\"\']{0,1}(.+)[\"\']{0,1}\)+/i)[1];
			}
		}
	});
})(jQuery);
