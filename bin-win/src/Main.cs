
#pragma warning disable 109, 114, 219, 429, 168, 162
public class EntryPoint__Main {
	public static void Main() {
		global::cs.Boot.init();
		global::Main.main();
	}
}

public class Main {
	
	public Main() {
	}
	
	
	public static void main() {
		unchecked {
			global::Gtk.Application.Init();
			global::Gtk.Window win = new global::Gtk.Window(((string) ("Simpleclock") ));
			win.SetDefaultSize(((int) (256) ), ((int) (256) ));
			global::Gtk.DeleteEventHandler __temp_stmt1 = null;
			{
				global::Gtk.DeleteEventHandler this1 = null;
				this1 = ((global::Gtk.DeleteEventHandler) (( (( global::Main_main_15__Fun.__hx_current != null )) ? (global::Main_main_15__Fun.__hx_current) : (global::Main_main_15__Fun.__hx_current = ((global::Main_main_15__Fun) (new global::Main_main_15__Fun()) )) ).Delegate) );
				__temp_stmt1 = ((global::Gtk.DeleteEventHandler) (this1) );
			}
			
			( win as global::Gtk.Widget ).DeleteEvent += ((global::Gtk.DeleteEventHandler) (__temp_stmt1) );
			global::Simpleclock clock = new global::Simpleclock(win);
			( win as global::Gtk.Container ).Add(((global::Gtk.Widget) (clock) ));
			( win as global::Gtk.Widget ).ShowAll();
			global::Gtk.Application.Run();
		}
	}
	
	
}



#pragma warning disable 109, 114, 219, 429, 168, 162
public class Main_main_15__Fun : global::haxe.lang.Function {
	
	public Main_main_15__Fun() : base(2, 0) {
	}
	
	
	public static global::Main_main_15__Fun __hx_current;
	
	public override object __hx_invoke2_o(double __fn_float1, object __fn_dyn1, double __fn_float2, object __fn_dyn2) {
		global::Gtk.DeleteEventArgs e = ( (( __fn_dyn2 == global::haxe.lang.Runtime.undefined )) ? (((global::Gtk.DeleteEventArgs) (((object) (__fn_float2) )) )) : (((global::Gtk.DeleteEventArgs) (__fn_dyn2) )) );
		object t = ( (( __fn_dyn1 == global::haxe.lang.Runtime.undefined )) ? (((object) (__fn_float1) )) : (((object) (__fn_dyn1) )) );
		this.Delegate(t, e);
		return null;
	}
	
	
	public void Delegate(object t, global::Gtk.DeleteEventArgs e) {
		global::Gtk.Application.Quit();
		( e as global::GLib.SignalArgs ).RetVal = ((object) (true) );
	}
	
	
}



#pragma warning disable 109, 114, 219, 429, 168, 162
public class Simpleclock : global::Gtk.DrawingArea {
	
	public Simpleclock(global::Gtk.Window win) : base() {
		unchecked {
			this.win = null;
			this.win = win;
			global::GLib.TimeoutHandler __temp_stmt1 = null;
			{
				global::GLib.TimeoutHandler this1 = null;
				this1 = ((global::GLib.TimeoutHandler) (this.updateClock) );
				__temp_stmt1 = ((global::GLib.TimeoutHandler) (this1) );
			}
			
			global::GLib.Timeout.Add(((uint) (500) ), ((global::GLib.TimeoutHandler) (__temp_stmt1) ));
		}
	}
	
	
	public global::Gtk.Window win;
	
	public virtual bool updateClock() {
		( this.win as global::Gtk.Widget ).QueueDraw();
		return true;
	}
	
	
	protected override bool OnExposeEvent(global::Gdk.EventExpose e) {
		global::Cairo.Context context = global::Gdk.CairoHelper.Create(((global::Gdk.Drawable) (( e as global::Gdk.Event ).Window) ));
		int w = ((int) (0) );
		int h = ((int) (0) );
		( ( e as global::Gdk.Event ).Window as global::Gdk.Drawable ).GetSize(out w, out h);
		this.draw(context, ((int) (w) ), ((int) (h) ));
		return true;
	}
	
	
	public virtual void draw(global::Cairo.Context context, int width, int height) {
		unchecked {
			double boxSize = global::System.Math.Min(((double) (width) ), ((double) (height) ));
			global::Date date = global::Date.now();
			context.Save();
			context.Color = ((global::Cairo.Color) (new global::Cairo.Color(((double) (1) ), ((double) (1) ), ((double) (1) ))) );
			context.Rectangle(((double) (0) ), ((double) (0) ), ((double) (width) ), ((double) (height) ));
			context.Fill();
			context.Restore();
			context.Translate(((double) (( (( width - boxSize )) / 2 )) ), ((double) (( (( height - boxSize )) / 2 )) ));
			context.Scale(((double) (( boxSize / 2 )) ), ((double) (( boxSize / 2 )) ));
			context.Translate(((double) (1.0) ), ((double) (1.0) ));
			context.Rotate(((double) ((  - (global::Math.PI)  / 2 )) ));
			this.drawClockFace(context);
			this.drawHourHand(context, date.date.Hour);
			this.drawMinuteHand(context, date.date.Minute);
			this.drawSecondHand(context, date.date.Second);
			this.drawPin(context);
			context.Restore();
		}
	}
	
	
	public virtual void drawPin(global::Cairo.Context context) {
		unchecked {
			context.Save();
			context.Arc(((double) (0) ), ((double) (0) ), ((double) (0.1) ), ((double) (0) ), ((double) (( 2 * global::Math.PI )) ));
			context.Color = ((global::Cairo.Color) (new global::Cairo.Color(((double) (1) ), ((double) (0) ), ((double) (0) ))) );
			context.Fill();
			context.Restore();
		}
	}
	
	
	public virtual void drawClockFace(global::Cairo.Context context) {
		unchecked {
			context.Save();
			context.Color = ((global::Cairo.Color) (new global::Cairo.Color(((double) (0) ), ((double) (0) ), ((double) (0) ))) );
			context.Arc(((double) (0) ), ((double) (0) ), ((double) (0.95) ), ((double) (0) ), ((double) (( 2 * global::Math.PI )) ));
			context.LineWidth = ((double) (0.01) );
			context.Stroke();
			context.Restore();
		}
	}
	
	
	public virtual void drawHourHand(global::Cairo.Context context, int hour) {
		unchecked {
			double rot = ( ( hour % 12 ) / 12.0 );
			context.Save();
			context.Rotate(((double) (( ( rot * global::Math.PI ) * 2.0 )) ));
			context.Rectangle(((double) (0) ), ((double) (-0.04) ), ((double) (0.8) ), ((double) (0.08) ));
			context.Color = ((global::Cairo.Color) (new global::Cairo.Color(((double) (0) ), ((double) (0) ), ((double) (0) ))) );
			context.Fill();
			context.Restore();
		}
	}
	
	
	public virtual void drawMinuteHand(global::Cairo.Context context, int minutes) {
		double rot = ( minutes / 60.0 );
		context.Save();
		context.Rotate(((double) (( ( rot * global::Math.PI ) * 2.0 )) ));
		context.Rectangle(((double) (0) ), ((double) (-0.02) ), ((double) (0.9) ), ((double) (0.04) ));
		context.Color = ((global::Cairo.Color) (new global::Cairo.Color(((double) (0) ), ((double) (0) ), ((double) (0) ))) );
		context.Fill();
		context.Restore();
	}
	
	
	public virtual void drawSecondHand(global::Cairo.Context context, int seconds) {
		double rot = ( seconds / 60.0 );
		context.Save();
		context.Rotate(((double) (( ( rot * global::Math.PI ) * 2.0 )) ));
		context.Rectangle(((double) (0) ), ((double) (-0.01) ), ((double) (0.9) ), ((double) (0.02) ));
		context.Color = ((global::Cairo.Color) (new global::Cairo.Color(((double) (0) ), ((double) (0) ), ((double) (0) ))) );
		context.Fill();
		context.Restore();
	}
	
	
}


