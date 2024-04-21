package com.example.webservice.service.impl;

import com.example.webservice.dto.EmailDetail;
import com.example.webservice.entity.User;
import com.example.webservice.repository.UserRepository;
import com.example.webservice.service.MailService;
import jakarta.mail.MessagingException;
import jakarta.mail.internet.MimeMessage;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.core.io.FileSystemResource;
import org.springframework.mail.SimpleMailMessage;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.mail.javamail.MimeMessageHelper;
import org.springframework.stereotype.Service;

import java.io.File;
import java.util.Objects;
import java.util.Optional;
import java.util.Random;
import java.util.UUID;

@Service
@RequiredArgsConstructor
public class MailServiceImpl implements MailService {
    private final JavaMailSender javaMailSender;
    private final UserRepository userRepository;

    @Value("${spring.mail.username}")
    private String sender;

    //Send email with simple email
    @Override
    public String sendVerifyEmail(EmailDetail emailDetail){
        try {
            SimpleMailMessage simpleMailMessage = new SimpleMailMessage();

            EmailDetail _emailDetail = new EmailDetail();
            emailDetail.setSubject("Click the link to verify the account");
            emailDetail.setRecipient(emailDetail.getRecipient());
            String token = UUID.randomUUID().toString();
            Optional<User> user = userRepository.findByEmail(emailDetail.getRecipient());
            if (user.isPresent()){
                User _user = user.get();
                _user.setVerifyToken(token);
                userRepository.save(_user);
            }
            else {
                throw new Exception("Email not exist");
            }
            emailDetail.setMessage("http://localhost:8080/auth/verify?token="+ token);

            simpleMailMessage.setFrom(sender);
            simpleMailMessage.setSubject(emailDetail.getSubject());
            simpleMailMessage.setTo(emailDetail.getRecipient());
            simpleMailMessage.setText(emailDetail.getMessage());
            javaMailSender.send(simpleMailMessage);

            return "Mail sent successfully";
        }
        catch (Exception e){
            return e.getMessage();
        }
    }

    @Override
    public String sendForgetMail(EmailDetail emailDetail) {
        try {
            SimpleMailMessage simpleMailMessage = new SimpleMailMessage();

            EmailDetail _emailDetail = new EmailDetail();
            emailDetail.setSubject("Click the link to restore the password");
            emailDetail.setRecipient(emailDetail.getRecipient());
            emailDetail.setMessage("http://localhost:8080/auth/forget?email=" + emailDetail.getRecipient());

            simpleMailMessage.setFrom(sender);
            simpleMailMessage.setSubject(emailDetail.getSubject());
            simpleMailMessage.setTo(emailDetail.getRecipient());
            simpleMailMessage.setText(emailDetail.getMessage());
            javaMailSender.send(simpleMailMessage);

            return "Mail sent successfully";
        }
        catch (Exception e){
            return e.getMessage();
        }
    }

    //Send email with attachment use MimeMessage
    @Override
    public String sendEmailWithAttachment(EmailDetail emailDetailAttachment){
        MimeMessage mimeMessage = javaMailSender.createMimeMessage();
        MimeMessageHelper mimeMessageHelper;

        try {
            mimeMessageHelper = new MimeMessageHelper(mimeMessage, true);

            mimeMessageHelper.setFrom(sender);
            mimeMessageHelper.setSubject(emailDetailAttachment.getSubject());
            mimeMessageHelper.setTo(emailDetailAttachment.getRecipient());
            mimeMessageHelper.setText(emailDetailAttachment.getMessage());

            //Adding the attachment
            FileSystemResource fileSystemResource = new FileSystemResource(new File(emailDetailAttachment.getAttachment()));
            mimeMessageHelper.addAttachment(Objects.requireNonNull(fileSystemResource.getFilename()),fileSystemResource);
            javaMailSender.send(mimeMessage);
            return "Mail sent successfully";

        } catch (MessagingException e) {
            return "Error";
        }
    }
}
