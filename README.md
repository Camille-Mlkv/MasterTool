Приложение "Master Tool" предназначено для оптимизации работы сервисных центров, обеспечивая эффективный учет, управление сервисными услугами.
Предметная область – система управления предприятием.
-------------------------------------------------------------------------------------------------------------------------------------------------
Сущности приложения:
1. Пользователь
2. Клиент
3. Мастер
4. Администратор
5. Заявка
6. Заказ
7. Материал
8. Деталь
9. Касса
10. Уведомление
11. Книга жалоб и предложений
12. Банковская карта
13. Склад
-------------------------------------------------------------------------------------------------------------------------
Параметры, связи, отношения и принципы взаимодействия сущностей с другими в виде диаграммы классов:
Принципы взаимодействия всех сущностей основаны на функционировании ключевых из них: клиента, мастера и администратора.
- Клиент взаимодействует с заявкой, заказом, книгой жалоб, уведомлением, банковской картой.
- Мастер взаимодействует с заявкой, заказом, складом, уведомлением.
- Админ взаимодействует с клиентами, мастерами, кассой, книгой жалоб, складом.
------------------------------------------------------------------------------------------------------------------------
Описание всех функций приложения:
1. User:
- Id – уникальный идентификатор;
- Username – уникальное имя пользователя, необходимое для дальнейшего входа в систему;
- Password – пароль, необходимый для дальнейшего входа в систему;
- Name – имя пользователя;
- Surname – фамилия пользователя;
- PhoneNumber – номер телефона;
- Email – электронный адрес.
- SignUp() – регистрация в системе. В окне приложения будет предложено ввести персональные данные, а также придумать уникальное имя пользователя и пароль. После этого будет предложена регистрация в качестве клиента, мастера и администратора. При выборе второго или третьего варианта будет предложено ввести ключ подтверждения, который был предварительно выдан пользователю. Если данный ключ является валидным, регистрация пройдет успешно, в противном случае учетная запись не будет создана. В случае регистрации клиента ключ не требуется;
- LogIn() – вход в систему. Пользователю будет предложено ввести имя пользователя и пароль;
- LogOut() – выход из системы. Все данные будут сохранены.
-----------------------------------------------------------------------------------------------------
2. Client (наследуется от User):
- Id – уникальный идентификатор для каждого клиента;
- Card – банковская карта для оплаты заказа;
- Requests – заявки. Заявка будет находиться в списке до тех пор, пока на нее не откликнется мастер. При отклике заявка будет удалена;
- Orders – заказы. Заказы формируются на основе принятой мастером заявки;
- Notifications – уведомления. Уведомление будет получено в случае отклика на заявку, изменения статуса заявки.
- MakeRequest() – оформить заявку;
- CheckOrders() – просмотреть список своих заказов;
- SeeOrderDetails() – просмотреть детали заказа, которые добавляет мастер;
- Complain() – добавить жалобу или предложение в книгу жалоб и предложений.
- AddCard() – добавить банковскую карту для оплаты заказа. Необходимо будет добавить номер карты, срок действия и cvv-код. 
- PayByCard() – оплатить готовый заказ банковской картой. 
- TakeItemBack() – забрать починенный товар. Будет предложено 2 варианта доставки: самовывоз (адрес цеха будет указан) и доставка курьером по заданному адресу. В случае выбора второго варианта необходимо будет заполнить поле с адресом. После этого будут предложены способы оплаты: наличными или банковской картой. При выборе второго варианта произойдет вызов метода PayByCard().
- ----------------------------------------------------------------------------------------------------
3. Administrator (наследуется от User):
- Id – уникальный идентификатор для каждого админа;
- Key – уникальный ключ, необходимый только для регистрации в системе в качестве админа. После этого ключ больше не будет доступен;
- CheckClientsList() – просмотреть список клиентов, зарегистрированных в системе. Будут доступны имя, фамилия, номер телефона, почтовый ящик и количество заказов клиента;
- CheckMastersList() – просмотреть список мастеров, зарегистрированных в системе. Будут доступны имя, фамилия, номер телефона, почтовый ящик и список заказов мастера;
- OpenCashbox() – открыть кассу. Данная функция предоставляет админу доступ к окну с кассой цеха;
- AddNoteToCashbox() – добавить запись в кассу. Записи могут быть следующего характера:инвестиции, налоги, выплаты мастерам. Доход от заказов мастеров и расход при покупке деталей и материалов приходит в кассу автоматически;
- CheckStorage() – проверить склад. Будут доступны все имеющиеся на складе детали и материалы;
- AddItemToStorage() – добавить деталь или материал на склад. Будут предложены соответствующие поля для ввода данных;
- CheckComplainBook() – просмотреть книгу жалоб и предложений для контроля работы мастеров;
----------------------------------------------------------------------------------------------------------------
4. Master (наследуется от User)
- Id – уникальный идентификатор для каждого мастера;
- Key – уникальный ключ, необходимый только для регистрации в системе в качестве мастера. После этого ключ больше не будет доступен;
- Orders – список заказов, над которыми работает мастер;
- FindClient() – найти клиента среди тех, кто оставил заявки, по определенному критерию (тип услуги);
- AcceptRequest() – откликнуться на заявку. При отклике на заявку срабатывает метод SendNotification();
- SendNotification() – отправить уведомление клиенту, на заявку которого мастер откликнулся. В уведомлении будут указаны персональные данные мастера, а также будет предоставлена возможность оставить комментарий (например, о сроках работы, стоимости работы без учета запчастей);
- CheckOrders() – просмотреть список заказов;
- SeeOrderDetails() – просмотреть детали для каждого заказа (обнаруженные неисправности, факт использования деталей и материала со склада);
- AddDefects() – добавить обнаруженные неисправности в заказ.
- AddDetailsToOrder() – добавить к заказу детали и материалы, которые понадобились в процессе ремонта с указанием их характеристик и стоимости;
- ChangeOrderStatus() – изменить статус заказа (в обработке/подбор запчастей/ремонт/тестирование/готов);
- FindDetail() – найти деталь или материал на складе с помощью поисковой системы. Поиск можно осуществлять по наименованию;
- ReserveDetail() – зарезервировать деталь или материал, необходимые для выполнения заказа. Количество деталей/объем материала будут автоматически уменьшены, а их стоимость будет прибавлена к стоимости заказа;
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
5. ComplaintBook (доступен для клиента и админа):
- Messages – сообщения, которые содержит книга жалоб и предложений:
- Category – категория сообщения (жалоба / предложение);
- Text – текст сообщения;
- ClientName – имя клиента, оставившего сообщение;
- AddNote() – добавить сообщение в книгу жалоб и предложений.
---------------------------------------------------------------------
6. CreditCard (доступен для клиента):
- Number – номер карты;
- CVV – код проверки подлинности карты;
- ExpiryDate – дата окончания действия карты.
----------------------------------------------------------------------
7. Cashbox (доступен для админа):
- Notes – история кассы, содержащая сведения о доходах и расходах:
- IsIncome – доход/расход;
- Info – общая информация;
- Sum – сумма дохода/расхода;
- AddNote() – добавить в кассу сведения о доходе/расходе.
---------------------------------------------------------------------
8. Notification (доступен для клиента и мастера):
- Id – уникальный идентификатор уведомления;
- Message – текст уведомления;
- RequestId – уникальный идентификатор соответствующего запроса.
--------------------------------------------------------------------
9. Request (доступен для клиента и мастера):
- Id – уникальный идентификатор запроса;
- Service – вид услуги (диагностика/починка/замена детали);
- ItemType – вид товара (бытовая техника/электронная техника/производственная техника);
- Problem – непосредственное описание поломки в виде списка проблем;
- UsageTime – время пользования товаром;
- Manufacturer – производитель товара;
- ClientId – уникальный идентификатор клиента-автора заявки;
- AddProblem() – добавить неполадку.
------------------------------------------------------------------------------------
10. Order (доступен для мастера и клиента):
- Id – уникальный идентификатор заказа;
- Date – дата формирования заказа;
- BaseRequest – запрос, на основе которого был сформирован заказ;
- MasterId – id мастера, выполняющего заказ;
- Status – статус заказа;
- Price – стоимость выполнения заказа (устанавливается мастером);
- Details – детали, приобретенные для выполнения заказа;
- Materials – материалы, приобретенные для выполнения заказа;
- ModifyRequestProblem() – дополнить (при необходимости) список проблем/неполадок устройства.
- AddDetails() – добавить детали к заказу;
- AddMaterials() – добавить материалы к заказу.
--------------------------------------------------------------------------------------------
11. Detail (доступен для мастера и админа):
- Id – уникальный идентификатор детали;
- Name – наименование детали;
- Manufacturer – производитель;
- Price – стоимость;
- Amount – количество.
12. Material (доступен для мастера и админа):
- Id – уникальный идентификатор материала;
- Name – наименование материала;
- Tarif – стоимость материала за 1 кг;
- Weight – масса материала.
----------------------------------------------------
13. Storage (доступен для мастера и админа):
- Details – детали, хранящиеся на складе;
- Materials – материалы, хранящиеся на складе;
- ModifyItems() – изменить склад. Здесь подразумевается резервация деталей и материалов мастерами.
- AddItems() – добавить вещи на склад. Здесь подразумевается добавление товара на склад админами.
-------------------------------------------------------------------------------------------------
![Class diagram](https://github.com/Camille-Mlkv/MasterTool/blob/main/chart_MT.png)