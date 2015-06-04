package;

/**
 * Main
 * @author 
 * https://github.com/kig/simpleclock/blob/master/simpleclock.cs
 */

@:nativeGen class Main 
{
	static function main() {
		gtk.Application.Init();
		var win = new gtk.Window('Simpleclock');
		win.SetDefaultSize(256, 256);
		win.add_DeleteEvent(new gtk.DeleteEventHandler(function(t:Dynamic, e:gtk.DeleteEventArgs) { 
			gtk.Application.Quit();
			e.set_RetVal(true);
		} ));
		var clock = new Simpleclock(win);
		win.Add(clock);
		win.ShowAll();
		gtk.Application.Run();
	}
}

@:nativeGen class Simpleclock extends gtk.DrawingArea {
	
	var win:gtk.Window = null;
	
	public function new(win) {
		super();
		this.win = win;
		glib.Timeout.Add(500, new glib.TimeoutHandler(this.updateClock));
	}
	
	function updateClock():Bool {
		win.QueueDraw();
		return true;
	}
	
	@:overload @:protected override function OnExposeEvent(e: gdk.EventExpose):Bool {
		var context:cairo.Context = gdk.CairoHelper.Create(e.Window);
		var w:cs.Out<Int> = 0;
		var h:cs.Out<Int> = 0;
		e.Window.GetSize(w, h);
		this.draw(context, w, h);
		return true;
	}
	
	function draw(context:cairo.Context, width:Int, height:Int) {
		var boxSize = Math.min(width, height);
		var date:Date = Date.now();
		
		context.Save();
		context.Color = new cairo.Color(1, 1, 1);
		context.Rectangle(0, 0, width, height);
		context.Fill();
		context.Restore();
		
		context.Translate((width - boxSize) / 2, (height - boxSize) / 2);
		context.Scale(boxSize / 2, boxSize / 2);
		context.Translate(1.0, 1.0);
		context.Rotate( -Math.PI / 2);
		
		this.drawClockFace(context);
		this.drawHourHand(context, date.getHours());
		this.drawMinuteHand(context, date.getMinutes());
		this.drawSecondHand(context, date.getSeconds());
		this.drawPin(context);
		context.Restore();
	}
	
	function drawPin(context:cairo.Context) {
		context.Save();
		context.Arc(0, 0, 0.1, 0, 2 * Math.PI);
		context.Color = new cairo.Color(1, 0, 0);
		context.Fill();
		context.Restore();
	}
	
	function drawClockFace(context:cairo.Context) {
		context.Save();
		context.Color = new cairo.Color(0, 0, 0);
		context.Arc(0, 0, 0.95, 0, 2 * Math.PI);
		context.LineWidth = 0.01;
		context.Stroke();
		context.Restore();
	}
	
	function drawHourHand(context:cairo.Context, hour:Int) {
		var rot = (hour % 12) / 12.0;
		context.Save();
		context.Rotate(rot * Math.PI * 2.0);
		context.Rectangle(0, -0.04, 0.8, 0.08);
		context.Color = new cairo.Color(0, 0, 0);
		context.Fill();
		context.Restore();
	}

	function drawMinuteHand(context:cairo.Context, minutes:Int) {
		var rot = minutes / 60.0;
		context.Save();
		context.Rotate(rot * Math.PI * 2.0);
		context.Rectangle(0, -0.02, 0.9, 0.04);
		context.Color = new cairo.Color(0, 0, 0);
		context.Fill();
		context.Restore();
	}

	function drawSecondHand(context:cairo.Context, seconds:Int) {
		var rot = seconds / 60.0;
		context.Save();
		context.Rotate(rot * Math.PI * 2.0);
		context.Rectangle(0, -0.01, 0.9, 0.02);
		context.Color = new cairo.Color(0, 0, 0);
		context.Fill();
		context.Restore();
	}
	
}