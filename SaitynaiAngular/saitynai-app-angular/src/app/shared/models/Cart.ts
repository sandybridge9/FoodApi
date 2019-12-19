import {User} from './User';
import {CartItem} from './CartItem';

export class Cart {
  Id: number;
  Name: string;
  CartItems: CartItem[];
  UserId: number;
  User: User;
  IsSelected: boolean;
}
