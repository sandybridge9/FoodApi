import {FoodItem} from './FoodItem';
import {Cart} from './Cart';

export class CartItem {
  Id: number;
  FoodItemId: number;
  FoodItem: FoodItem;
  CartId: number;
  Cart: Cart;
  Count: number;
}
