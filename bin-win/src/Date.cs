
#pragma warning disable 109, 114, 219, 429, 168, 162
public class Date : global::haxe.lang.HxObject {
	
	public Date(global::haxe.lang.EmptyObject empty) {
	}
	
	
	public Date(int year, int month, int day, int hour, int min, int sec) {
		global::Date.__hx_ctor__Date(this, year, month, day, hour, min, sec);
	}
	
	
	public static void __hx_ctor__Date(global::Date __temp_me7, int year, int month, int day, int hour, int min, int sec) {
		unchecked {
			if (( day <= 0 )) {
				day = 1;
			}
			
			if (( year <= 0 )) {
				year = 1;
			}
			
			__temp_me7.date = new global::System.DateTime(year, ( month + 1 ), day, hour, min, sec);
		}
	}
	
	
	public static global::Date now() {
		global::Date d = new global::Date(0, 0, 0, 0, 0, 0);
		d.date = global::System.DateTime.Now;
		return d;
	}
	
	
	public static new object __hx_createEmpty() {
		return new global::Date(global::haxe.lang.EmptyObject.EMPTY);
	}
	
	
	public static new object __hx_create(global::Array arr) {
		unchecked {
			return new global::Date(((int) (global::haxe.lang.Runtime.toInt(arr[0])) ), ((int) (global::haxe.lang.Runtime.toInt(arr[1])) ), ((int) (global::haxe.lang.Runtime.toInt(arr[2])) ), ((int) (global::haxe.lang.Runtime.toInt(arr[3])) ), ((int) (global::haxe.lang.Runtime.toInt(arr[4])) ), ((int) (global::haxe.lang.Runtime.toInt(arr[5])) ));
		}
	}
	
	
	public global::System.DateTime date;
	
	public override object __hx_setField(string field, int hash, object @value, bool handleProperties) {
		unchecked {
			switch (hash) {
				case 1113806382:
				{
					this.date = ((global::System.DateTime) (@value) );
					return @value;
				}
				
				
				default:
				{
					return base.__hx_setField(field, hash, @value, handleProperties);
				}
				
			}
			
		}
	}
	
	
	public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties) {
		unchecked {
			switch (hash) {
				case 1113806382:
				{
					return this.date;
				}
				
				
				default:
				{
					return base.__hx_getField(field, hash, throwErrors, isCheck, handleProperties);
				}
				
			}
			
		}
	}
	
	
	public override void __hx_getFields(global::Array<object> baseArr) {
		baseArr.push("date");
		{
			base.__hx_getFields(baseArr);
		}
		
	}
	
	
}


