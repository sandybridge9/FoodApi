import {UserLogin} from './UserLogin';
import {Cart} from './Cart';

export class User {
  Id: number;
  Name: string;
  UserLoginId: number;
  UserLogin: UserLogin;
  Carts: Cart[];
}
