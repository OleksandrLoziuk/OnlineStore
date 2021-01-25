export interface OrderDetail {
    id: number;
    clientName: string;
    clientSurname: string;
    patronymic: string;
    phoneNumber: string;
    email: string;
    deliveryMethod: string;
    place: string;
    placeNumber: number;
    paymentMethod: string,
    clientId: number;
    sumOrder: number;
    dateTimeOrder: string;
    statusName: string;
}
