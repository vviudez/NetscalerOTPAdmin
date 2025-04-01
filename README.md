# Netscaler OTP Admin
User TOTP Administration for Netscaler, using a AD service user.

Based on the idea of Andreas Nick (https://www.andreasnick.com/102-otpedit.html), I've build a similar solution for the administration
of seeds on the Active Directory attribute, but instead of the user running the application having admin permissions or attribute modification permissions, we use an Active Directory service user, as an intermediary, just like in Netscaler for LDAP queries. In fact, it could be the same user for both cases.


Main Screen:
![main](https://github.com/user-attachments/assets/62e513c8-7dc6-4d67-b82e-804917818f8a)

Add new OTP seed to user:
![new_user_otp](https://github.com/user-attachments/assets/d3a47309-cb0d-44af-9365-e4cc22be7e8a)

Edit user OTP seeds:
![edit_user_otp](https://github.com/user-attachments/assets/e23fb3de-d44b-4d91-b052-d6abea758453)

Settings:
![settings](https://github.com/user-attachments/assets/f878e963-4bab-47a5-a8b8-a26891ad5f41)

